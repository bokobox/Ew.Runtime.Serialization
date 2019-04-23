using System;
using NUnit.Framework;

namespace Ew.Runtime.Serialization.Test.初期値.値型
{
    public class デシリアライズ
    {
        /*
           string
           bool
           char
           sbyte
           byte
           short
           ushort
           int
           uint
           long
           ulong
           float
           decimal
           byte[]
           DateTime
           DateTimeOffset
        */

        //3回シリアライズとデシリアライズを行い、元データと比較する

        [Test]
        public void stringテスト()
        {
            const string value = default(string);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<string>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void boolテスト()
        {
            const bool value = default(bool);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<bool>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void charテスト()
        {
            const char value = default(char);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<char>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void sbyteテスト()
        {
            const sbyte value = default(sbyte);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<sbyte>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void byteテスト()
        {
            const byte value = default(byte);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<byte>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void shortテスト()
        {
            const short value = default(short);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<short>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void ushortテスト()
        {
            const ushort value = default(ushort);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<ushort>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void intテスト()
        {
            const int value = default(int);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<int>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void uintテスト()
        {
            const uint value = default(uint);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<uint>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void longテスト()
        {
            const long value = default(long);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<long>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void ulongテスト()
        {
            const ulong value = default(ulong);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<ulong>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void floatテスト()
        {
            const float value = default(float);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<float>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void decimalテスト()
        {
            const decimal value = default(decimal);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<decimal>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void doubleテスト()
        {
            const decimal value = default(decimal);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<decimal>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void bytesテスト()
        {
            const byte[] value = default(byte[]);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<byte[]>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void DateTimeテスト()
        {
            var value = default(DateTime);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<DateTime>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        public void DateTimeOffsetテスト()
        {
            var value = default(DateTimeOffset);
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<DateTimeOffset>(bin);
            }

            Assert.AreEqual(value, value2);
        }
    }
}