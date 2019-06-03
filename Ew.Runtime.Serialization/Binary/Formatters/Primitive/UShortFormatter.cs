using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class UShortFormatter : BinaryFormatter<ushort>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (ushort) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref InternalBufferWriter writer, ushort value)
        {
            const int size = sizeof(ushort);
            writer.Append(value, size).Size(size);
        }

        public override ushort Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<ushort>(size);
        }
    }
}