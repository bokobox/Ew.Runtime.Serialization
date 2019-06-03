using System;
using Ew.Runtime.Serialization.Binary.Formatters;
using Ew.Runtime.Serialization.Binary.Formatters.Primitive;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Factory
{
    public static class PrimitiveFormatterFactory
    {
        public static IBinaryFormatable<T> Build<T>()
        {
            if (typeof(T) == typeof(string)) return (IBinaryFormatable<T>) new StringFormatter();
            if (typeof(T) == typeof(bool)) return (IBinaryFormatable<T>) new BoolFormatter();
            if (typeof(T) == typeof(char)) return (IBinaryFormatable<T>) new CharFormatter();
            if (typeof(T) == typeof(sbyte)) return (IBinaryFormatable<T>) new SbyteFormatter();
            if (typeof(T) == typeof(byte)) return (IBinaryFormatable<T>) new ByteFormatter();
            if (typeof(T) == typeof(short)) return (IBinaryFormatable<T>) new ShortFormatter();
            if (typeof(T) == typeof(ushort)) return (IBinaryFormatable<T>) new UShortFormatter();
            if (typeof(T) == typeof(int)) return (IBinaryFormatable<T>) new IntFormatter();
            if (typeof(T) == typeof(uint)) return (IBinaryFormatable<T>) new UIntFormatter();
            if (typeof(T) == typeof(long)) return (IBinaryFormatable<T>) new LongFormatter();
            if (typeof(T) == typeof(ulong)) return (IBinaryFormatable<T>) new ULongFormatter();
            if (typeof(T) == typeof(float)) return (IBinaryFormatable<T>) new FloatFormatter();
            if (typeof(T) == typeof(double)) return (IBinaryFormatable<T>) new DoubleFormatter();
            if (typeof(T) == typeof(decimal)) return (IBinaryFormatable<T>) new DecimalFormatter();
            if (typeof(T) == typeof(DateTime)) return (IBinaryFormatable<T>) new DateTimeFormatter();
            if (typeof(T) == typeof(DateTimeOffset)) return (IBinaryFormatable<T>) new DateTimeOffsetFormatter();
            if (typeof(T) == typeof(byte[])) return (IBinaryFormatable<T>) new ByteArrayFormatter();

            return null;
        }
    }
}