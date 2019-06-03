using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class CharFormatter : BinaryFormatter<char>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (char) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref InternalBufferWriter writer, char value)
        {
            const int size = sizeof(char);
            writer.Append(value, size).Size(size);
        }

        public override char Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<char>(size);
        }
    }
}