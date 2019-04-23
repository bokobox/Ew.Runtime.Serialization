using System;
using System.Runtime.CompilerServices;

namespace Ew.Runtime.Serialization.Internal.Binary
{
    public static class BitConverterExtension
    {
        public static unsafe byte[] GetBytes(decimal value)
        {
            const int size = sizeof(decimal);
            return new Span<byte>(Unsafe.AsPointer(ref value), size).ToArray();
        }

        public static unsafe byte[] GetBytes<T>(T[] values) where T : struct
        {
            var size = Unsafe.SizeOf<T>() * values.Length;
            return new Span<byte>(Unsafe.AsPointer(ref values[0]), size).ToArray();
        }

        public static unsafe byte[] GetBytes(DateTime value)
        {
            var size = sizeof(DateTime);
            return new Span<byte>(Unsafe.AsPointer(ref value), size).ToArray();
        }

        public static unsafe byte[] GetBytes(DateTimeOffset value)
        {
            var size = sizeof(DateTimeOffset);
            return new Span<byte>(Unsafe.AsPointer(ref value), size).ToArray();
        }

        public static unsafe T[] ToArray<T>(byte[] bytes) where T : struct
        {
            var size = Unsafe.SizeOf<T>();
            var values = new T[bytes.Length / size];
            var srtPtr = Unsafe.AsPointer(ref bytes[0]);
            var destPtr = Unsafe.AsPointer(ref values[0]);
            Unsafe.CopyBlock(destPtr, srtPtr, (uint) bytes.Length);
            return values;
        }

        public static unsafe decimal ToDecimal(byte[] bytes)
        {
            const int size = sizeof(decimal);
            var value = new decimal();
            var srtPtr = Unsafe.AsPointer(ref bytes[0]);
            var destPtr = Unsafe.AsPointer(ref value);
            Unsafe.CopyBlock(destPtr, srtPtr, size);
            return value;
        }

        public static unsafe DateTime ToDateTime(byte[] bytes)
        {
            var size = sizeof(DateTime);
            var value = new DateTime();
            var srtPtr = Unsafe.AsPointer(ref bytes[0]);
            var destPtr = Unsafe.AsPointer(ref value);
            Unsafe.CopyBlock(destPtr, srtPtr, (uint) size);
            return value;
        }

        public static unsafe DateTimeOffset ToDateTimeOffset(byte[] bytes)
        {
            var size = sizeof(DateTimeOffset);
            var value = new DateTimeOffset();
            var srtPtr = Unsafe.AsPointer(ref bytes[0]);
            var destPtr = Unsafe.AsPointer(ref value);
            Unsafe.CopyBlock(destPtr, srtPtr, (uint) size);
            return value;
        }
    }
}