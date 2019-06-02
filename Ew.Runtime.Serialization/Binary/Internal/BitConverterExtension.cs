using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Ew.Runtime.Serialization.Binary.Internal
{
    public static class BitConverterExtension
    {
        #region ToBytes

        public static byte[] GetBytes(bool value)
        {
            var r = new byte[1];
            r[0] = value ? (byte) 1 : (byte) 0;
            return r;
        }

        public static byte[] GetBytes(char value)
        {
            var bytes = new byte[sizeof(char)];
            Unsafe.As<byte, char>(ref bytes[0]) = value;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] GetBytes(sbyte value)
        {
            var bytes = new byte[sizeof(sbyte)];
            Unsafe.As<byte, sbyte>(ref bytes[0]) = value;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            bytes[0] ^= 0x80;
            return bytes;
        }

        public static byte[] GetBytes(byte value)
        {
            return new[] {value};
        }

        public static byte[] GetBytes(short value)
        {
            var bytes = new byte[sizeof(short)];
            Unsafe.As<byte, short>(ref bytes[0]) = value;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            bytes[0] ^= 0x80;
            return bytes;
        }

        public static byte[] GetBytes(ushort value)
        {
            var bytes = new byte[sizeof(ushort)];
            Unsafe.As<byte, ushort>(ref bytes[0]) = value;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] GetBytes(int value)
        {
            var bytes = new byte[sizeof(int)];
            Unsafe.As<byte, int>(ref bytes[0]) = value;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            bytes[0] ^= 0x80;
            return bytes;
        }

        public static byte[] GetBytes(uint value)
        {
            var bytes = new byte[sizeof(uint)];
            Unsafe.As<byte, uint>(ref bytes[0]) = value;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] GetBytes(long value)
        {
            var bytes = new byte[sizeof(long)];
            Unsafe.As<byte, long>(ref bytes[0]) = value;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            bytes[0] ^= 0x80;
            return bytes;
        }

        public static byte[] GetBytes(ulong value)
        {
            var bytes = new byte[sizeof(ulong)];
            Unsafe.As<byte, ulong>(ref bytes[0]) = value;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] GetBytes(float value)
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

            var bytes = new byte[sizeof(float)];
            Unsafe.As<byte, int>(ref bytes[0]) = i;

            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] GetBytes(double value)
        {
            //https://ja.wikipedia.org/wiki/%E5%80%8D%E7%B2%BE%E5%BA%A6%E6%B5%AE%E5%8B%95%E5%B0%8F%E6%95%B0%E7%82%B9%E6%95%B0
            var i = BitConverter.ToInt64(BitConverter.GetBytes(value), 0);

            i ^= 1 << 63;
            i ^= 1 << 62;

            var bytes = new byte[sizeof(double)];
            Unsafe.As<byte, long>(ref bytes[0]) = i;

            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }

        public static byte[] GetBytes(decimal value)
        {
            var bits = decimal.GetBits(value);

            //https://qiita.com/nia_tn1012/items/9810d821d76dd765c59c
            bits[0] ^= 1 << 31;
            bits[0] ^= 1 << 22;

            return bits.SelectMany(GetBytes).ToArray();
        }

        public static unsafe byte[] GetBytes(DateTime value)
        {
            var bytes = new byte[sizeof(DateTime)];
            Unsafe.As<byte, DateTime>(ref bytes[0]) = value;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }

        public static unsafe byte[] GetBytes(DateTimeOffset value)
        {
            var bytes = new byte[sizeof(DateTimeOffset)];
            Unsafe.As<byte, DateTimeOffset>(ref bytes[0]) = value;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return bytes;
        }

        #endregion


        #region FromBytes

        public static bool ToBool(byte[] bytes)
        {
            return bytes[0] == 1;
        }

        public static char ToChar(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return Unsafe.As<byte, char>(ref bytes[0]);
        }

        public static sbyte ToSByte(byte[] bytes)
        {
            bytes[0] ^= 0x80;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return Unsafe.As<byte, sbyte>(ref bytes[0]);
        }

        public static byte ToByte(byte[] bytes)
        {
            return bytes[0];
        }

        public static short ToShort(byte[] bytes)
        {
            bytes[0] ^= 0x80;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return Unsafe.As<byte, short>(ref bytes[0]);
        }

        public static ushort ToUShort(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return Unsafe.As<byte, ushort>(ref bytes[0]);
        }

        public static int ToInt(byte[] bytes)
        {
            bytes[0] ^= 0x80;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return Unsafe.As<byte, int>(ref bytes[0]);
        }

        public static uint ToUInt(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return Unsafe.As<byte, uint>(ref bytes[0]);
        }

        public static long ToLong(byte[] bytes)
        {
            bytes[0] ^= 0x80;
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return Unsafe.As<byte, long>(ref bytes[0]);
        }

        public static ulong ToULong(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return Unsafe.As<byte, ulong>(ref bytes[0]);
        }

        public static float ToFloat(byte[] bytes)
        {
            //https://ja.wikipedia.org/wiki/%E5%8D%98%E7%B2%BE%E5%BA%A6%E6%B5%AE%E5%8B%95%E5%B0%8F%E6%95%B0%E7%82%B9%E6%95%B0
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            var i = BitConverter.ToInt32(bytes, 0);

            i ^= 1 << 31;
            i ^= 1 << 30;

            return BitConverter.ToSingle(BitConverter.GetBytes(i), 0);
        }

        public static double ToDouble(byte[] bytes)
        {
            //https://ja.wikipedia.org/wiki/%E5%8D%98%E7%B2%BE%E5%BA%A6%E6%B5%AE%E5%8B%95%E5%B0%8F%E6%95%B0%E7%82%B9%E6%95%B0
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            var i = BitConverter.ToInt64(bytes, 0);

            i ^= 1 << 63;
            i ^= 1 << 62;

            return BitConverter.ToDouble(BitConverter.GetBytes(i), 0);
        }

        public static DateTime ToDateTime(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return Unsafe.As<byte, DateTime>(ref bytes[0]);
        }

        public static DateTimeOffset ToDateTimeOffset(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
            return Unsafe.As<byte, DateTimeOffset>(ref bytes[0]);
        }

        public static decimal ToDecimal(byte[] bytes)
        {
            var bits = new int[sizeof(decimal) / sizeof(int)];
            var span = new Span<byte>(bytes);
            for (var i = 0; i < bits.Length; i++) bits[i] = ToInt(span.Slice(i * sizeof(int), sizeof(int)).ToArray());

            //https://qiita.com/nia_tn1012/items/9810d821d76dd765c59c
            bits[0] ^= 1 << 31;
            bits[0] ^= 1 << 22;

            return new decimal(bits);
        }

        #endregion
    }
}