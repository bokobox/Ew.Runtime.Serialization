using System;
using Ew.Runtime.Serialization.Binary.Internal;
using K4os.Compression.LZ4;

namespace Ew.Runtime.Serialization
{
    public static class BinarySerializer
    {
        public static void Register<T>(Func<object, byte[]> serialize, Func<byte[], object> deserialize)
        {
            InternalBinarySerializer.Serializers.Add(typeof(T), serialize);
            InternalBinaryDeserializer.Deserializers.Add(typeof(T), deserialize);
        }

        public static byte[] Serialize<T>(T value)
        {
            return InternalBinarySerializer.Serialize(value);
        }

        public static T Deserialize<T>(byte[] bin)
        {
            return InternalBinaryDeserializer.Deserialize<T>(bin);
        }

        public static byte[] LZ4Serialize<T>(T value)
        {
            return LZ4Pickler.Pickle(InternalBinarySerializer.Serialize(value));
        }

        public static T LZ4Deserialize<T>(byte[] bin)
        {
            return InternalBinaryDeserializer.Deserialize<T>(LZ4Pickler.Unpickle(bin));
        }
    }
}