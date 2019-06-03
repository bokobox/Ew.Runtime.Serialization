using System.Text;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class StringFormatter : IBinaryFormatable<string>, IDynamicBinaryFormatable
    {
        public void Serialize(ref InternalBufferWriter writer, string value)
        {
            var bin = value == null ? new byte[] { } : Encoding.UTF8.GetBytes(value);
            if (bin.Length == 0)
                writer.Size(0);
            else
                writer.Append(bin).Size(bin.Length);
        }

        public void Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (string)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public string Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            if (size == 0)
                return default;
            
            var bin = reader.Data(size);
            return Encoding.UTF8.GetString(bin);
        }
    }
}