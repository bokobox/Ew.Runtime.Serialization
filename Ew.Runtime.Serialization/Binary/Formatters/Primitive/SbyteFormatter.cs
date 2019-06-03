using System;
using System.Runtime.CompilerServices;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class SbyteFormatter : IBinaryFormatable<sbyte>
    {
        public void Serialize(ref InternalBufferWriter writer, sbyte value)
        {
            var bin = new byte[sizeof(sbyte)];
            Unsafe.As<byte, sbyte>(ref bin[0]) = value;
            if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            bin[0] ^= 0x80;
            
            writer.Append(bin).Append(bin.Length);
        }

        public void Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (sbyte)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public sbyte Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            var bin = reader.Data(size);

            bin[0] ^= 0x80;
            if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            return Unsafe.As<byte, sbyte>(ref bin[0]);
        }
    }
}