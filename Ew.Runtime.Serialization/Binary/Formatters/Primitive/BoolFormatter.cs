using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class BoolFormatter : IBinaryFormatable<bool>
    {
        public void Serialize(ref InternalBufferWriter writer, bool value)
        {
            var bin = BitConverterExtension.GetBytes(value);
            writer.Append(bin).Append(bin.Length);
        }

        public void Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (bool)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public bool Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            var bin = reader.Data(size);
            
            return BitConverterExtension.ToBool(bin);
        }
    }
}