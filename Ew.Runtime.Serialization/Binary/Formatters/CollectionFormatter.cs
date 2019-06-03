using System.Collections.Generic;
using System.Linq;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters
{
    public class CollectionFormatter<T> : BinaryFormatter<T[]>, IDynamicBinaryFormatable
    {
        private readonly BinaryFormatter<T> _internalFormatter;

        public CollectionFormatter(BinaryFormatter<T> internalFormatter)
        {
            _internalFormatter = internalFormatter;
        }

        public override void Serialize(ref InternalBufferWriter writer, T[] collection)
        {
            var items = collection?.ToArray();
            if (items == null)
            {
                writer.Size(0);
                return;
            }
            
            foreach (var item in items)
                _internalFormatter.Serialize(ref writer, item);

            writer.Size(items.Length);
        }

        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (T[])value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override T[] Deserialize(ref InternalBufferReader reader)
        {
            var count = reader.Size();
            if (count == 0)
                return null;
            
            var items = new T[count];

            for (var j = count - 1; j >= 0; j--)
                items[j] = _internalFormatter.Deserialize(ref reader);

            return items;
        }
    }
}