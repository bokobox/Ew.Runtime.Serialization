using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters
{
    public class BoolFormatter  : IBinaryFormatable<bool>
    {
        public byte[] Serialize(bool value)
        {
            return BitConverterExtension.GetBytes(value);
        }

        public bool Deserialize(byte[] bin)
        {
            return BitConverterExtension.ToBool(bin);
        }
    }
}