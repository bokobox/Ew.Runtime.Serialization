using System;
using Ew.Runtime.Serialization.Binary.Internal;
using Ew.Runtime.Serialization.Binary.Resolvers;
using K4os.Compression.LZ4;

namespace Ew.Runtime.Serialization
{
    public static class BinarySerializer
    {
        public static byte[] Serialize<T>(T value)
        {
            var writer = InternalBufferWriter.GetBuffer(0);
            var formatter = StandardResolver<T>.GetFormatter();
            formatter.Serialize(ref writer, value);

            return writer.ToArray();
        }

        public static T Deserialize<T>(byte[] bin)
        {
            if (bin.Length == 0)
                return default;
            
            var reader = new InternalBufferReader(bin);
            var formatter = StandardResolver<T>.GetFormatter();
            return (T) formatter.Deserialize(ref reader);
        }

        public static byte[] LZ4Serialize<T>(T value)
        {
            var writer = InternalBufferWriter.GetBuffer(0);
            var formatter = StandardResolver<T>.GetFormatter();
            formatter.Serialize(ref writer, value);

            return LZ4Pickler.Pickle(writer.ToArray());
        }

        public static T LZ4Deserialize<T>(byte[] bin)
        {
            var reader = new InternalBufferReader(LZ4Pickler.Unpickle(bin));
            var formatter = StandardResolver<T>.GetFormatter();
            return (T) formatter.Deserialize(ref reader);
        }
    }
}