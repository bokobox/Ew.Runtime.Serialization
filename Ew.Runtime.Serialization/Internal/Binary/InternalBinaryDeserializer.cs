using System;
using System.Collections;
using System.Text;

namespace Ew.Runtime.Serialization.Internal.Binary
{
    internal static class InternalBinaryDeserializer
    {
        private static readonly ThreadSafeHashTypeTable<Func<byte[], object>> Deserializers;

        static InternalBinaryDeserializer()
        {
            var deserializers = new ThreadSafeHashTypeTable<Func<byte[], object>>();

            deserializers.Add(typeof(string),
                o => o == null || o.Length == 0 ? string.Empty : Encoding.Unicode.GetString(o));
            deserializers.Add(typeof(bool), o => BitConverter.ToBoolean(o, 0));
            deserializers.Add(typeof(char), o => BitConverter.ToChar(o, 0));
            deserializers.Add(typeof(sbyte), o => (sbyte) o[0]);
            deserializers.Add(typeof(byte), o => o[0]);
            deserializers.Add(typeof(short), o => BitConverter.ToInt16(o, 0));
            deserializers.Add(typeof(ushort), o => BitConverter.ToUInt16(o, 0));
            deserializers.Add(typeof(int), o => BitConverter.ToInt32(o, 0));
            deserializers.Add(typeof(uint), o => BitConverter.ToUInt32(o, 0));
            deserializers.Add(typeof(long), o => BitConverter.ToInt64(o, 0));
            deserializers.Add(typeof(ulong), o => BitConverter.ToUInt64(o, 0));
            deserializers.Add(typeof(float), o => BitConverter.ToSingle(o, 0));
            deserializers.Add(typeof(double), o => BitConverter.ToDouble(o, 0));
            deserializers.Add(typeof(byte[]), o => o);
            deserializers.Add(typeof(decimal), o => BitConverterExtension.ToDecimal(o));
            deserializers.Add(typeof(DateTime), o => BitConverterExtension.ToDateTime(o));
            deserializers.Add(typeof(DateTimeOffset), o => BitConverterExtension.ToDateTimeOffset(o));

            deserializers.Add(typeof(bool[]), BitConverterExtension.ToArray<bool>);
            deserializers.Add(typeof(char[]), BitConverterExtension.ToArray<char>);
            deserializers.Add(typeof(sbyte[]), BitConverterExtension.ToArray<sbyte>);
            deserializers.Add(typeof(short[]), BitConverterExtension.ToArray<short>);
            deserializers.Add(typeof(ushort[]), BitConverterExtension.ToArray<ushort>);
            deserializers.Add(typeof(int[]), BitConverterExtension.ToArray<int>);
            deserializers.Add(typeof(uint[]), BitConverterExtension.ToArray<uint>);
            deserializers.Add(typeof(long[]), BitConverterExtension.ToArray<long>);
            deserializers.Add(typeof(ulong[]), BitConverterExtension.ToArray<ulong>);
            deserializers.Add(typeof(float[]), BitConverterExtension.ToArray<float>);
            deserializers.Add(typeof(double[]), BitConverterExtension.ToArray<double>);
            deserializers.Add(typeof(decimal[]), BitConverterExtension.ToArray<decimal>);
            deserializers.Add(typeof(DateTime[]), BitConverterExtension.ToArray<DateTime>);
            deserializers.Add(typeof(DateTimeOffset[]), BitConverterExtension.ToArray<DateTimeOffset>);

            Deserializers = deserializers;
        }


        public static T Deserialize<T>(byte[] bytes)
        {
            return (T) Deserialize(typeof(T), bytes);
        }

        public static object Deserialize(Type type, byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return default;

            if (Deserializers.TryGetValue(type, out var deserializer))
                return deserializer(bytes);

            if (type.IsArray)
                return DeserializeArray(type.GetElementType(), bytes);

            var adapters = AdapterStore.GetPropertyAdapters(type, true);
            var instance = InstanceActivator.GetInstance(type);

            var buffer = new InternalBufferReader(bytes);
            foreach (var adapter in adapters)
            {
                var len = buffer.Size();
                if (len == 0)
                {
                    //NOP
                }
                else if (Deserializers.TryGetValue(adapter.PropertyType, out var d))
                {
                    var value = d(buffer.Data(len));
                    adapter.Set(instance, value);
                }
                else
                {
                    var o = Deserialize(adapter.PropertyType, buffer.Data(len));
                    adapter.Set(instance, o);
                }
            }

            return instance;
        }

        private static object DeserializeArray(Type itemType, byte[] bytes)
        {
            if (itemType == null)
                throw new NullReferenceException();

            var buffer = new InternalBufferReader(bytes);
            var count = buffer.Size();
            var items = (IList) Array.CreateInstance(itemType, count);

            for (var j = count - 1; j >= 0; j--)
            {
                var itemLen = buffer.Size();
                items[j] = Deserialize(itemType, buffer.Data(itemLen));
            }

            return items;
        }
    }
}