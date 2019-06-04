using System;
using System.Runtime.CompilerServices;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class DoubleFormatter : BinaryFormatter<double>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (double) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, double value)
        {
            //https://ja.wikipedia.org/wiki/%E5%80%8D%E7%B2%BE%E5%BA%A6%E6%B5%AE%E5%8B%95%E5%B0%8F%E6%95%B0%E7%82%B9%E6%95%B0
            var i = Unsafe.As<double, long>(ref value);

            i ^= 1 << 63;
            i ^= 1 << 62;

            var bin = new byte[sizeof(double)];
            Unsafe.As<byte, long>(ref bin[0]) = i;

            //if (BitConverter.IsLittleEndian) Array.Reverse(bin);

            writer.Append(bin).Size(bin.Length);
        }

        public override double Deserialize(ref BinaryBufferReader reader)
        {
            var size = reader.Size();
            var bin = reader.Data(size);

            //https://ja.wikipedia.org/wiki/%E5%8D%98%E7%B2%BE%E5%BA%A6%E6%B5%AE%E5%8B%95%E5%B0%8F%E6%95%B0%E7%82%B9%E6%95%B0
            //if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            var i = BitConverter.ToInt64(bin, 0);

            i ^= 1 << 63;
            i ^= 1 << 62;

            return BitConverter.ToDouble(BitConverter.GetBytes(i), 0);
        }
    }
}