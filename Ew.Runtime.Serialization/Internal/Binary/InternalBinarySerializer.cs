using System;
using System.Text;

namespace Ew.Runtime.Serialization.Internal.Binary
{
    internal static class InternalBinarySerializer
    {
        private static readonly ThreadSafeHashTypeTable<Func<object, byte[]>> Serializers;

        static InternalBinarySerializer()
        {
            var serializers = new ThreadSafeHashTypeTable<Func<object, byte[]>>();

            serializers.Add(typeof(string), o => o == null ? new byte[] { } : Encoding.Unicode.GetBytes((string) o));
            serializers.Add(typeof(bool), o => BitConverter.GetBytes((bool) o));
            serializers.Add(typeof(char), o => BitConverter.GetBytes((char) o));
            serializers.Add(typeof(sbyte), o => BitConverter.GetBytes((sbyte) o));
            serializers.Add(typeof(byte), o => BitConverter.GetBytes((byte) o));
            serializers.Add(typeof(short), o => BitConverter.GetBytes((short) o));
            serializers.Add(typeof(ushort), o => BitConverter.GetBytes((ushort) o));
            serializers.Add(typeof(int), o => BitConverter.GetBytes((int) o));
            serializers.Add(typeof(uint), o => BitConverter.GetBytes((uint) o));
            serializers.Add(typeof(long), o => BitConverter.GetBytes((long) o));
            serializers.Add(typeof(ulong), o => BitConverter.GetBytes((ulong) o));
            serializers.Add(typeof(float), o => BitConverter.GetBytes((float) o));
            serializers.Add(typeof(double), o => BitConverter.GetBytes((double) o));
            serializers.Add(typeof(decimal), o => BitConverterExtension.GetBytes((decimal) o));
            serializers.Add(typeof(DateTime), o => BitConverterExtension.GetBytes((DateTime) o));
            serializers.Add(typeof(DateTimeOffset), o => BitConverterExtension.GetBytes((DateTimeOffset) o));
            serializers.Add(typeof(byte[]), o => (byte[]) o ?? new byte[] { });

            serializers.Add(typeof(bool[]), o => BitConverterExtension.GetBytes((bool[]) o));
            serializers.Add(typeof(char[]), o => BitConverterExtension.GetBytes((char[]) o));
            serializers.Add(typeof(sbyte[]), o => BitConverterExtension.GetBytes((sbyte[]) o));
            serializers.Add(typeof(short[]), o => BitConverterExtension.GetBytes((short[]) o));
            serializers.Add(typeof(ushort[]), o => BitConverterExtension.GetBytes((ushort[]) o));
            serializers.Add(typeof(int[]), o => BitConverterExtension.GetBytes((int[]) o));
            serializers.Add(typeof(uint[]), o => BitConverterExtension.GetBytes((uint[]) o));
            serializers.Add(typeof(long[]), o => BitConverterExtension.GetBytes((long[]) o));
            serializers.Add(typeof(ulong[]), o => BitConverterExtension.GetBytes((ulong[]) o));
            serializers.Add(typeof(float[]), o => BitConverterExtension.GetBytes((float[]) o));
            serializers.Add(typeof(double[]), o => BitConverterExtension.GetBytes((double[]) o));
            serializers.Add(typeof(decimal[]), o => BitConverterExtension.GetBytes((decimal[]) o));
            serializers.Add(typeof(DateTime[]), o => BitConverterExtension.GetBytes((DateTime[]) o));
            serializers.Add(typeof(DateTimeOffset[]), o => BitConverterExtension.GetBytes((DateTimeOffset[]) o));

            Serializers = serializers;
        }

        public static byte[] Serialize<T>(T instance, int layer = 0)
        {
            return Serialize(typeof(T), instance, layer);
        }

        public static byte[] Serialize(Type type, object instance, int layer = 0)
        {
            if (instance == null)
                return new byte[] { };

            if (Serializers.TryGetValue(type, out var serializer))
                return serializer(instance);

            if (type.IsArray)
                return SerializeArray(type.GetElementType(), (Array) instance, layer);

            var adapters = AdapterStore.GetPropertyAdapters(type, false);
            var buffer = InternalBufferWriter.GetBuffer(layer);

            foreach (var adapter in adapters)
            {
                var value = adapter.Get(instance);
                if (value == null)
                {
                    buffer.Append(0);
                }
                else if (Serializers.TryGetValue(adapter.PropertyType, out var s))
                {
                    var bin = s(value);
                    buffer.Append(bin).Append(bin.Length);
                }
                else
                {
                    var bin = Serialize(adapter.PropertyType, value, layer + 1);
                    buffer.Append(bin).Append(bin.Length);
                }
            }

            return buffer.ToArray();
        }

        private static byte[] SerializeArray(Type type, Array items, int layer)
        {
            var buffer = InternalBufferWriter.GetBuffer(layer);
            var itemType = type;

            foreach (var item in items)
            {
                var bin = Serialize(itemType, item, layer + 1);
                buffer.Append(bin).Append(bin.Length);
            }

            buffer.Append(items.Length);
            return buffer.ToArray();
        }
    }
}