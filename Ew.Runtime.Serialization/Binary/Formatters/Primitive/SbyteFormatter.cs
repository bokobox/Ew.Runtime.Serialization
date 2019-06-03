using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class SbyteFormatter : BinaryFormatter<sbyte>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (sbyte) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref InternalBufferWriter writer, sbyte value)
        {
            const int size = sizeof(sbyte);
            writer.Append(value, size).Size(size);
        }

        public override sbyte Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<sbyte>(size);
        }
    }
}