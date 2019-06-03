using System.Runtime.CompilerServices;

namespace Ew.Runtime.Serialization.Binary.Internal
{
    public class InternalBufferReader
    {
        private readonly byte[] _buffer;
        private int _offset;

        public InternalBufferReader(byte[] buffer)
        {
            _buffer = buffer;
            _offset = buffer.Length;
        }

        public int Size()
        {
            const int size = sizeof(int);
            _offset -= size;
            return Unsafe.As<byte, int>(ref _buffer[_offset]);
        }

        public byte[] Data(int size)
        {
            _offset -= size;
            var value = new byte[size];
            Unsafe.CopyBlock(ref value[0], ref _buffer[_offset], (uint) size);

            return value;
        }

        public T Data<T>(int size)
        {
            _offset -= size;
            return Unsafe.As<byte, T>(ref _buffer[_offset]);
        }

        public byte Data()
        {
            _offset -= 1;
            return _buffer[_offset];
        }
    }
}