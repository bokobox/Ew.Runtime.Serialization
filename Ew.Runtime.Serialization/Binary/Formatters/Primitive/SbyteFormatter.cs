using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class SbyteFormatter : BinaryFormatter<sbyte>, IDynamicBinaryFormatable
    {
        public override void Serialize(ref InternalBufferWriter writer, sbyte value)
        {
            const int size = sizeof(sbyte);
            value = (sbyte) (value ^ 0x80);
            writer.Append(value, size).Size(size);
        }

        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (sbyte)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override sbyte Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            var bin = reader.Data(size);

            bin[0] ^= 0x80;
            //if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            return Unsafe.As<byte, sbyte>(ref bin[0]);
        }
    }
}