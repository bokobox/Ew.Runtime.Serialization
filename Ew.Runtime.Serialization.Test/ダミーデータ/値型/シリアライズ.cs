using System;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace Ew.Runtime.Serialization.Test.ダミーデータ.値型
{
    public class シリアライズ
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

        [Test]
        [AutoData]
        public void stringテスト(string value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void boolテスト(bool value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void charテスト(char value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void sbyteテスト(sbyte value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void byteテスト(byte value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void shortテスト(short value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void ushortテスト(ushort value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void intテスト(int value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void uintテスト(uint value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void longテスト(long value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void ulongテスト(ulong value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void floatテスト(float value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void decimalテスト(decimal value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void doubleテスト(double value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void bytesテスト(byte[] value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void DateTimeテスト(DateTime value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void DateTimeOffsetテスト(DateTimeOffset value)
        {
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }
    }
}