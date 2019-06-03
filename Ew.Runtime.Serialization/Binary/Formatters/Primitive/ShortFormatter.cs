using System;
using System.Runtime.CompilerServices;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class ShortFormatter : IBinaryFormatable<short>
    {
        public void Serialize(ref InternalBufferWriter writer, short value)
        {
            var bin = new byte[sizeof(short)];
            Unsafe.As<byte, short>(ref bin[0]) = value;
            if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            bin[0] ^= 0x80;
            
            writer.Append(bin).Append(bin.Length);
        }

        public void Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (short)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public short Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            var bin = reader.Data(size);

            bin[0] ^= 0x80;
            if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            return Unsafe.As<byte, short>(ref bin[0]);
        }
    }
}