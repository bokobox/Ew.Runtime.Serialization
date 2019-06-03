using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ew.Runtime.Serialization.Binary.Internal
{
    public class InternalBufferWriter
    {
        private static byte[] _sharedBuffer;

        private readonly byte[] _buffer;
        private int _length;

        private InternalBufferWriter(byte[] buffer)
        {
            _buffer = buffer;
            _length = 0;
        }

        public static InternalBufferWriter GetBuffer()
        {
            var buffer = _sharedBuffer ?? (_sharedBuffer = new byte[ushort.MaxValue]);
            return new InternalBufferWriter(buffer);
        }

        public InternalBufferWriter Append<T>(T value, int size)
        {
            Unsafe.As<byte, T>(ref _buffer[_length]) = value;
            _length += size;
            return this;
        }
        
        public InternalBufferWriter Append(byte[] bin)
        {
            Unsafe.CopyBlock(ref _buffer[_length], ref bin[0], (uint) bin.Length);
            _length += bin.Length;
            return this;
        }

        public InternalBufferWriter Append(byte bin)
        {
            _buffer[_length] = bin;
            _length++;
            return this;
        }

        public InternalBufferWriter Size(int value)
        {
            const int size = sizeof(int);
            Unsafe.As<byte, int>(ref _buffer[_length]) = value;
            _length += size;
            return this;
        }

        public byte[] ToArray()
        {
            if (_length == 0)
                return new byte[] {};
            
            var buffer = new byte[_length];
            Unsafe.CopyBlock(ref buffer[0], ref _buffer[0], (uint) _length);
            return buffer;
        }
    }
}