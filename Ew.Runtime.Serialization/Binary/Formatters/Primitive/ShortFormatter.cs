using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class ShortFormatter : BinaryFormatter<short>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (short) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, short value)
        {
            const int size = sizeof(short);
            writer.Append(value, size).Size(size);
        }

        public override short Deserialize(ref BinaryBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<short>(size);
        }
    }
}