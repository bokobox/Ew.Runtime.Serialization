using System.Collections.Generic;
using System.Linq;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Generic
{
    public class EnumerableFormatter<T> : BinaryFormatter<IEnumerable<T>>, IDynamicBinaryFormatable
    {
        private readonly BinaryFormatter<T> _internalFormatter;

        public EnumerableFormatter(BinaryFormatter<T> internalFormatter)
        {
            _internalFormatter = internalFormatter;
        }

        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (T[]) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, IEnumerable<T> collection)
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

        public override IEnumerable<T> Deserialize(ref BinaryBufferReader reader)
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