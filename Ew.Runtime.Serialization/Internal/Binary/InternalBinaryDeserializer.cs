using System;
using System.Collections;
using System.Text;

namespace Ew.Runtime.Serialization.Internal.Binary
{
    internal static class InternalBinaryDeserializer
    {
        public static readonly ThreadSafeHashTypeTable<Func<byte[], object>> Deserializers;

        static InternalBinaryDeserializer()
        {
            var deserializers = new ThreadSafeHashTypeTable<Func<byte[], object>>();

            deserializers.Add(typeof(string),
                o => o == null || o.Length == 0 ? string.Empty : Encoding.Unicode.GetString(o));

            deserializers.Add(typeof(bool), o => BitConverterExtension.ToBool(o));
            deserializers.Add(typeof(char), o => BitConverterExtension.ToChar(o));
            deserializers.Add(typeof(sbyte), o => BitConverterExtension.ToSByte(o));
            deserializers.Add(typeof(byte), o => BitConverterExtension.ToByte(o));
            deserializers.Add(typeof(short), o => BitConverterExtension.ToShort(o));
            deserializers.Add(typeof(ushort), o => BitConverterExtension.ToUShort(o));
            deserializers.Add(typeof(int), o => BitConverterExtension.ToInt(o));
            deserializers.Add(typeof(uint), o => BitConverterExtension.ToUInt(o));
            deserializers.Add(typeof(long), o => BitConverterExtension.ToLong(o));
            deserializers.Add(typeof(ulong), o => BitConverterExtension.ToULong(o));
            deserializers.Add(typeof(float), o => BitConverterExtension.ToFloat(o));
            deserializers.Add(typeof(double), o => BitConverterExtension.ToDouble(o));
            deserializers.Add(typeof(decimal), o => BitConverterExtension.ToDecimal(o));
            deserializers.Add(typeof(DateTime), o => BitConverterExtension.ToDateTime(o));
            deserializers.Add(typeof(DateTimeOffset), o => BitConverterExtension.ToDateTimeOffset(o));
            deserializers.Add(typeof(byte[]), o => o);

            Deserializers = deserializers;
        }


        public static T Deserialize<T>(byte[] bytes)
        {
            return (T) Deserialize(typeof(T), bytes);
        }

        public static object Deserialize(Type type, byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return default;

            if (Deserializers.TryGetValue(type, out var deserializer))
                return deserializer(bytes);

            if (type.IsArray)
                return DeserializeArray(type.GetElementType(), bytes);

            var adapters = AdapterStore.GetPropertyAdapters(type, true);
            var instance = InstanceActivator.GetInstance(type);

            var buffer = new InternalBufferReader(bytes);
            foreach (var adapter in adapters)
            {
                var len = buffer.Size();
                if (len == 0)
                {
                    //NOP
                }
                else if (Deserializers.TryGetValue(adapter.PropertyType, out var d))
                {
                    var value = d(buffer.Data(len));
                    adapter.Set(instance, value);
                }
                else
                {
                    var o = Deserialize(adapter.PropertyType, buffer.Data(len));
                    adapter.Set(instance, o);
                }
            }

            return instance;
        }

        private static object DeserializeArray(Type itemType, byte[] bytes)
        {
            if (itemType == null)
                throw new NullReferenceException();

            var buffer = new InternalBufferReader(bytes);
            var count = buffer.Size();
            var items = (IList) Array.CreateInstance(itemType, count);

            for (var j = count - 1; j >= 0; j--)
            {
                var itemLen = buffer.Size();
                items[j] = Deserialize(itemType, buffer.Data(itemLen));
            }

            return items;
        }
    }
}