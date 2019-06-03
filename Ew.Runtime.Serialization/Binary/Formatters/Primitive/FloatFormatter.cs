using System;
using System.Runtime.CompilerServices;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class FloatFormatter : IBinaryFormatable<float>
    {
        public void Serialize(ref InternalBufferWriter writer, float value)
        {
            //本来は234

            //シリアライズ後のバイナリ
            //1000 0011 0110 1010 0000 0000 0000 0000

            //先頭2ビットを反転する
            //0100 0011 0110 1010 0000 0000 0000 0000

            //符号ビット0なので正数
            //指数部：1000 0110
            //仮数部：0110 1010 0000 0000 0000 0000
            //仮数部：1110 1010 0000 0000 0000 0000 (暗黙の上位ビット追加)
            //
            //指数値：
            //1000 0110(2) => 134(10)
            //134 - 127 = 7
            //
            //仮数：
            //立っているフラグを元に合算する数値を元に合計を算出
            //1 + 0.5 + 0.25 + 0.0625 + 0.015625 = 1.828125
            //
            //本来の値
            //仮数 * (2 ^ 指数) = 本来の値
            //1.828125 × 2^7 = 234 
            //OK

            //https://ja.wikipedia.org/wiki/%E5%8D%98%E7%B2%BE%E5%BA%A6%E6%B5%AE%E5%8B%95%E5%B0%8F%E6%95%B0%E7%82%B9%E6%95%B0
            var i = BitConverter.ToInt32(BitConverter.GetBytes(value), 0);

            i ^= 1 << 31;
            i ^= 1 << 30;

            var bin = new byte[sizeof(float)];
            Unsafe.As<byte, int>(ref bin[0]) = i;

            //if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            
            writer.Append(bin).Size(bin.Length);
        }

        public void Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (float)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public float Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            var bin = reader.Data(size);

            //https://ja.wikipedia.org/wiki/%E5%8D%98%E7%B2%BE%E5%BA%A6%E6%B5%AE%E5%8B%95%E5%B0%8F%E6%95%B0%E7%82%B9%E6%95%B0
            //if (BitConverter.IsLittleEndian) Array.Reverse(bin);
            var i = BitConverter.ToInt32(bin, 0);

            i ^= 1 << 31;
            i ^= 1 << 30;

            return BitConverter.ToSingle(BitConverter.GetBytes(i), 0);
        }
    }
}