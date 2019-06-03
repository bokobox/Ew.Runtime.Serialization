using System;
using System.Linq;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class DecimalFormatter : IBinaryFormatable<decimal>, IDynamicBinaryFormatable
    {
        public void Serialize(ref InternalBufferWriter writer, decimal value)
        {
            var bits = decimal.GetBits(value);

            //https://qiita.com/nia_tn1012/items/9810d821d76dd765c59c
            bits[0] ^= 1 << 31;
            bits[0] ^= 1 << 22;

            var bin = bits.SelectMany(BitConverter.GetBytes).ToArray();
            writer.Append(bin).Size(bin.Length);
        }

        public void Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (decimal)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public decimal Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            var bin = reader.Data(size);

            var bits = new int[sizeof(decimal) / sizeof(int)];
            var span = new Span<byte>(bin);
            for (var i = 0; i < bits.Length; i++)
                bits[i] = BitConverter.ToInt32(span.Slice(i * sizeof(int), sizeof(int)).ToArray(), 0);

            //https://qiita.com/nia_tn1012/items/9810d821d76dd765c59c
            bits[0] ^= 1 << 31;
            bits[0] ^= 1 << 22;

            return new decimal(bits);
        }
    }
}