using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Ew.Runtime.Serialization.Binary.Internal
{
    internal class InternalBufferWriter
    {
        [ThreadStatic] private static byte[][] Buffers;

        private readonly byte[] _buffer;
        private int _length;

        private InternalBufferWriter(byte[] buffer)
        {
            _buffer = buffer;
            _length = 0;
        }

        public static InternalBufferWriter GetBuffer(int layer)
        {
            if (Buffers == null)
            {
                var buffers = new List<byte[]>();
                for (var i = 0; i < 32; i++)
                    buffers.Add(new byte[ushort.MaxValue]);

                Buffers = buffers.ToArray();
            }

            return new InternalBufferWriter(Buffers[layer]);
        }

        public InternalBufferWriter Append(byte[] bin)
        {
            Unsafe.CopyBlock(ref _buffer[_length], ref bin[0], (uint) bin.Length);
            _length += bin.Length;
            return this;
        }

        public unsafe InternalBufferWriter Append(int value)
        {
            const int size = sizeof(int);
            var src = Unsafe.AsPointer(ref value);
            var dest = Unsafe.AsPointer(ref _buffer[_length]);
            Unsafe.CopyBlock(dest, src, size);
            _length += size;
            return this;
        }

        public byte[] ToArray()
        {
            var buffer = new byte[_length];
            Unsafe.CopyBlock(ref buffer[0], ref _buffer[0], (uint) _length);
            return buffer;
        }
    }
}