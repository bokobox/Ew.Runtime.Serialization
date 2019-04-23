using System;
using System.Collections.Generic;
using System.Threading;

namespace Ew.Runtime.Serialization.Internal
{
    //http://engineering.grani.jp/entry/2017/07/28/145035

    internal class ThreadSafeHashTypeTable<TValue>
    {
        private readonly IEqualityComparer<Type> _comparer;
        private readonly float _loadFactor;

        private readonly object _writerLock = new object();
        private Entry[] _buckets;
        private int _size; // only use in writer lock

        public ThreadSafeHashTypeTable()
            : this(EqualityComparer<Type>.Default)
        {
        }

        public ThreadSafeHashTypeTable(IEqualityComparer<Type> comaprer)
            : this(4, 0.75f, comaprer)
        {
        }

        public ThreadSafeHashTypeTable(int capacity, float loadFactor, IEqualityComparer<Type> comparer)
        {
            var tableSize = CalculateCapacity(capacity, loadFactor);
            _buckets = new Entry[tableSize];
            _loadFactor = loadFactor;
            _comparer = comparer;
        }

        public void Add(Type key, TValue value)
        {
            TryAddInternal(key, t => value, out _);
        }

        private void TryAddInternal(Type key, Func<Type, TValue> valueFactory, out TValue resultingValue)
        {
            lock (_writerLock)
            {
                var nextCapacity = CalculateCapacity(_size + 1, _loadFactor);

                if (_buckets.Length < nextCapacity)
                {
                    // rehash
                    var nextBucket = new Entry[nextCapacity];
                    foreach (var t in _buckets)
                    {
                        var e = t;
                        while (e != null)
                        {
                            var newEntry = new Entry {Key = e.Key, Value = e.Value, Hash = e.Hash};
                            AddToBuckets(nextBucket, key, newEntry, null, out resultingValue);
                            e = e.Next;
                        }
                    }

                    // add entry(if failed to add, only do resize)
                    var successAdd = AddToBuckets(nextBucket, key, null, valueFactory, out resultingValue);

                    // replace field(threadsafe for read)
                    Volatile.Write(ref _buckets, nextBucket);


                    if (successAdd) _size++;
                }
                else
                {
                    // add entry(insert last is thread safe for read)
                    var successAdd = AddToBuckets(_buckets, key, null, valueFactory, out resultingValue);
                    if (successAdd) _size++;
                }
            }
        }

        private bool AddToBuckets(Entry[] buckets, Type newKey, Entry newEntryOrNull, Func<Type, TValue> valueFactory,
            out TValue resultingValue)
        {
            var h = newEntryOrNull?.Hash ?? _comparer.GetHashCode(newKey);
            if (buckets[h & (buckets.Length - 1)] == null)
            {
                if (newEntryOrNull != null)
                {
                    resultingValue = newEntryOrNull.Value;
                    Volatile.Write(ref buckets[h & (buckets.Length - 1)], newEntryOrNull);
                }
                else
                {
                    resultingValue = valueFactory(newKey);
                    Volatile.Write(ref buckets[h & (buckets.Length - 1)],
                        new Entry {Key = newKey, Value = resultingValue, Hash = h});
                }
            }
            else
            {
                var searchLastEntry = buckets[h & (buckets.Length - 1)];
                while (true)
                {
                    if (_comparer.Equals(searchLastEntry.Key, newKey))
                    {
                        resultingValue = searchLastEntry.Value;
                        return false;
                    }

                    if (searchLastEntry.Next == null)
                    {
                        if (newEntryOrNull != null)
                        {
                            resultingValue = newEntryOrNull.Value;
                            Volatile.Write(ref searchLastEntry.Next, newEntryOrNull);
                        }
                        else
                        {
                            resultingValue = valueFactory(newKey);
                            Volatile.Write(ref searchLastEntry.Next,
                                new Entry {Key = newKey, Value = resultingValue, Hash = h});
                        }

                        break;
                    }

                    searchLastEntry = searchLastEntry.Next;
                }
            }

            return true;
        }

        public bool TryGetValue(Type key, out TValue value)
        {
            var table = _buckets;
            var hash = key.GetHashCode();
            var entry = table[hash & (table.Length - 1)];

            if (entry == null) goto NOT_FOUND;

            if (entry.Key == key)
            {
                value = entry.Value;
                return true;
            }

            var next = entry.Next;
            while (next != null)
            {
                if (next.Key == key)
                {
                    value = next.Value;
                    return true;
                }

                next = next.Next;
            }

            NOT_FOUND:
            value = default;
            return false;
        }

        private static int CalculateCapacity(int collectionSize, float loadFactor)
        {
            var initialCapacity = (int) (collectionSize / loadFactor);
            var capacity = 1;
            while (capacity < initialCapacity) capacity <<= 1;

            return capacity < 8 ? 8 : capacity;
        }

        private class Entry
        {
            public int Hash;
            public Type Key;
            public Entry Next;
            public TValue Value;

            // debug only
            public override string ToString()
            {
                return Key + "(" + Count() + ")";
            }

            private int Count()
            {
                var count = 1;
                var n = this;
                while (n.Next != null)
                {
                    count++;
                    n = n.Next;
                }

                return count;
            }
        }
    }
}