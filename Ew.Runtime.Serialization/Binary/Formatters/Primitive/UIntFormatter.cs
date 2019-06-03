using System;
using System.Runtime.CompilerServices;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class UIntFormatter : BinaryFormatter<uint>, IDynamicBinaryFormatable
    {
        public override void Serialize(ref InternalBufferWriter writer, uint value)
        {
            var bin = new byte[sizeof(uint)];
            Unsafe.As<byte, uint>(ref bin[0]) = value;
            //if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            
            writer.Append(bin).Size(bin.Length);
        }

        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (uint)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override uint Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            var bin = reader.Data(size);

            //if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            return Unsafe.As<byte, uint>(ref bin[0]);
        }
    }
}