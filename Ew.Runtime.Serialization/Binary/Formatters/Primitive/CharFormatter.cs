using System;
using System.Runtime.CompilerServices;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class CharFormatter : IBinaryFormatable<char>
    {
        public void Serialize(ref InternalBufferWriter writer, char value)
        {
            var bin = new byte[sizeof(char)];
            Unsafe.As<byte, char>(ref bin[0]) = value;
            if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            
            writer.Append(bin).Append(bin.Length);
        }

        public void Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (char)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public char Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            var bin = reader.Data(size);
            
            if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            return Unsafe.As<byte, char>(ref bin[0]);
        }
    }
}