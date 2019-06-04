using System;
using System.Runtime.CompilerServices;

namespace Ew.Runtime.Serialization.Binary
{
    public class BinaryBufferWriter
    {
        [ThreadStatic] private static byte[] _sharedBuffer;

        private readonly byte[] _buffer;
        private int _length;

        private BinaryBufferWriter(byte[] buffer)
        {
            _buffer = buffer;
            _length = 0;
        }

        public static BinaryBufferWriter GetWriter()
        {
            var buffer = _sharedBuffer ?? (_sharedBuffer = new byte[ushort.MaxValue]);
            return new BinaryBufferWriter(buffer);
        }

        public BinaryBufferWriter Append<T>(T value, int size)
        {
            Unsafe.As<byte, T>(ref _buffer[_length]) = value;
            _length += size;
            return this;
        }

        public BinaryBufferWriter Append(byte[] bin)
        {
            Unsafe.CopyBlock(ref _buffer[_length], ref bin[0], (uint) bin.Length);
            _length += bin.Length;
            return this;
        }

        public BinaryBufferWriter Append(byte bin)
        {
            _buffer[_length] = bin;
            _length++;
            return this;
        }

        public BinaryBufferWriter Size(int value)
        {
            const int size = sizeof(int);
            Unsafe.As<byte, int>(ref _buffer[_length]) = value;
            _length += size;
            return this;
        }

        public byte[] ToArray()
        {
            if (_length == 0)
                return new byte[] { };

            var buffer = new byte[_length];
            Unsafe.CopyBlock(ref buffer[0], ref _buffer[0], (uint) _length);
            return buffer;
        }
    }
}