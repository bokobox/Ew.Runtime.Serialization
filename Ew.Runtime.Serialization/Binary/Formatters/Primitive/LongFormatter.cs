using System;
using System.Runtime.CompilerServices;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class LongFormatter : IBinaryFormatable<long>, IDynamicBinaryFormatable
    {
        public void Serialize(ref InternalBufferWriter writer, long value)
        {
            var bin = new byte[sizeof(long)];
            Unsafe.As<byte, long>(ref bin[0]) = value;
            //if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            bin[0] ^= 0x80;
            
            writer.Append(bin).Size(bin.Length);
        }

        public void Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (long)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public long Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            var bin = reader.Data(size);

            bin[0] ^= 0x80;
            //if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            return Unsafe.As<byte, long>(ref bin[0]);
        }
    }
}