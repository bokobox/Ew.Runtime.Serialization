using System;
using Ew.Runtime.Serialization.Binary.Formatters.Primitive;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Factory
{
    public static class PrimitiveFormatterFactory
    {
        public static BinaryFormatter<T> Build<T>()
        {
            if (typeof(T) == typeof(string)) return new StringFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(bool)) return new BoolFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(char)) return new CharFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(sbyte)) return new SbyteFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(byte)) return new ByteFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(short)) return new ShortFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(ushort)) return new UShortFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(int)) return new IntFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(uint)) return new UIntFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(long)) return new LongFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(ulong)) return new ULongFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(float)) return new FloatFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(double)) return new DoubleFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(decimal)) return new DecimalFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(DateTime)) return new DateTimeFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(DateTimeOffset)) return new DateTimeOffsetFormatter() as BinaryFormatter<T>;
            if (typeof(T) == typeof(byte[])) return new ByteArrayFormatter() as BinaryFormatter<T>;

            return null;
        }
    }
}