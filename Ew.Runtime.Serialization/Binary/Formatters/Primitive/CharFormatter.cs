using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class CharFormatter : BinaryFormatter<char>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (char) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, char value)
        {
            const int size = sizeof(char);
            writer.Append(value, size).Size(size);
        }

        public override char Deserialize(ref BinaryBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<char>(size);
        }
    }
}