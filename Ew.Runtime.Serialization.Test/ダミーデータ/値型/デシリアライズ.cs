using System;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace Ew.Runtime.Serialization.Test.ダミーデータ.値型
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
        [AutoData]
        public void stringテスト(string value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<string>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void boolテスト(bool value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<bool>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void charテスト(char value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<char>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void sbyteテスト(sbyte value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<sbyte>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void byteテスト(byte value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<byte>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void shortテスト(short value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<short>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void ushortテスト(ushort value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<ushort>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void intテスト(int value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<int>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void uintテスト(uint value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<uint>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void longテスト(long value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<long>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void ulongテスト(ulong value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<ulong>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void floatテスト(float value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<float>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void decimalテスト(decimal value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<decimal>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void bytesテスト(byte[] value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<byte[]>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void DateTimeテスト(DateTime value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<DateTime>(bin);
            }

            Assert.AreEqual(value, value2);
        }

        [Test]
        [AutoData]
        public void DateTimeOffsetテスト(DateTimeOffset value)
        {
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