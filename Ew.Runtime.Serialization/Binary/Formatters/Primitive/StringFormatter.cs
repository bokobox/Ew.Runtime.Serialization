using System.Text;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class StringFormatter : IBinaryFormatable<string>
    {
        public void Serialize(ref InternalBufferWriter writer, string value)
        {
            var bin = value == null ? new byte[] { } : Encoding.UTF8.GetBytes(value);
            if (bin.Length > 0)
                writer.Append(bin).Append(bin.Length);
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
            var bin = reader.Data(size);

            return bin == null || bin.Length == 0 ? string.Empty : Encoding.UTF8.GetString(bin);
        }
    }
}