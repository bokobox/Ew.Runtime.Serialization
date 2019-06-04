using System.Text;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class StringFormatter : BinaryFormatter<string>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (string) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, string value)
        {
            var bin = value == null ? new byte[] { } : Encoding.Unicode.GetBytes(value);
            if (bin.Length == 0)
                writer.Size(0);
            else
                writer.Append(bin).Size(bin.Length);
        }

        public override string Deserialize(ref BinaryBufferReader reader)
        {
            var size = reader.Size();
            if (size == 0)
                return default;

            var bin = reader.Data(size);
            return Encoding.Unicode.GetString(bin);
        }
    }
}