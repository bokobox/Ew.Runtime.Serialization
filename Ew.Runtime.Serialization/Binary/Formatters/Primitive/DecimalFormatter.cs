using System.Runtime.CompilerServices;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class DecimalFormatter : BinaryFormatter<decimal>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (decimal) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref InternalBufferWriter writer, decimal value)
        {
            var bits = decimal.GetBits(value);

            //https://qiita.com/nia_tn1012/items/9810d821d76dd765c59c
            /*bits[0] ^= 1 << 31;
            bits[0] ^= 1 << 22;*/

            const int size = sizeof(int);
            writer.Append(bits[0], size)
                .Append(bits[1], size)
                .Append(bits[2], size)
                .Append(bits[3], size)
                .Size(size * 4);
        }

        public override decimal Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            var bin = reader.Data(size);

            var bits = new int[sizeof(decimal) / sizeof(int)];

            for (var i = 0; i < bits.Length; i++)
                bits[i] = Unsafe.As<byte, int>(ref bin[i * sizeof(int)]);

            //https://qiita.com/nia_tn1012/items/9810d821d76dd765c59c
            /*bits[0] ^= 1 << 31;
            bits[0] ^= 1 << 22;*/

            return new decimal(bits);
        }
    }
}