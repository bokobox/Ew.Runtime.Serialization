using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class IntFormatter : BinaryFormatter<int>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (int) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, int value)
        {
            const int size = sizeof(int);
            writer.Append(value, size).Size(size);
        }

        public override int Deserialize(ref BinaryBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<int>(size);
        }
    }
}