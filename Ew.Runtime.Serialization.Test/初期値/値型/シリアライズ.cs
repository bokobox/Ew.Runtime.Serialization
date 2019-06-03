using System;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace Ew.Runtime.Serialization.Test.初期値.値型
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
        public void stringテスト()
        {
            const string value = default(string);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsTrue(bin1.Length == sizeof(int));
        }

        [Test]
        public void boolテスト()
        {
            const bool value = default(bool);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        [AutoData]
        public void charテスト()
        {
            const char value = default(char);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }


        [Test]
        public void sbyteテスト()
        {
            const sbyte value = default(sbyte);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        public void byteテスト()
        {
            const byte value = default(byte);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        public void shortテスト()
        {
            const short value = default(short);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        public void ushortテスト()
        {
            const ushort value = default(ushort);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        public void intテスト()
        {
            const int value = default(int);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        public void uintテスト()
        {
            const uint value = default(uint);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        public void longテスト()
        {
            const long value = default(long);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        public void ulongテスト()
        {
            const ulong value = default(ulong);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        public void floatテスト()
        {
            const float value = default(float);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        public void decimalテスト()
        {
            const decimal value = default(decimal);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        public void doubleテスト()
        {
            const double value = default(double);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        public void bytesテスト()
        {
            const byte[] value = default(byte[]);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsTrue(bin1.Length == sizeof(int));
        }

        [Test]
        public void DateTimeテスト()
        {
            var value = default(DateTime);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }

        [Test]
        public void DateTimeOffsetテスト()
        {
            var value = default(DateTimeOffset);
            var bin1 = BinarySerializer.Serialize(value);
            Assert.NotNull(bin1);
            Assert.IsNotEmpty(bin1);
        }
    }
}