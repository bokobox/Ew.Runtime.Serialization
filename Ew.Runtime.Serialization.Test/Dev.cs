using System;
using System.Runtime.CompilerServices;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace Ew.Runtime.Serialization.Test
{
    public class Dev
    {
        [Test]
        [AutoData]
        public void Test(float value)
        {
            var i = BitConverter.ToInt32(BitConverter.GetBytes(value), 0);

            i ^= 1 << 31;
            i ^= 1 << 30;

            var bytes = new byte[sizeof(float)];
            Unsafe.As<byte, int>(ref bytes[0]) = i;

            if (BitConverter.IsLittleEndian) Array.Reverse(bytes);
        }
    }
}