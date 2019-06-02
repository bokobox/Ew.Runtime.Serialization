using System.Text;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters
{
    public class StringFormatter : IBinaryFormatable<string>
    {
        public byte[] Serialize(string value)
        {
            return value == null ? new byte[] { } : Encoding.UTF8.GetBytes(value);
        }

        public string Deserialize(byte[] bin)
        {
            return bin == null || bin.Length == 0 ? string.Empty : Encoding.Unicode.GetString(bin);
        }
    }
}