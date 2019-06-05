using Ew.Runtime.Serialization.Binary;
using Ew.Runtime.Serialization.Binary.Resolvers;
using K4os.Compression.LZ4;

namespace Ew.Runtime.Serialization
{
    public static class BinarySerializer
    {
        public static byte[] Serialize<T>(T value)
        {
            var writer = BinaryBufferWriter.GetWriter();
            var formatter = StandardResolver<T>.GetFormatter();
            formatter.Serialize(ref writer, value);

            return writer.ToArray();
        }

        public static T Deserialize<T>(byte[] bin)
        {
            if (bin == null || bin.Length == 0)
                return default;

            var reader = new BinaryBufferReader(bin);
            var formatter = StandardResolver<T>.GetFormatter();
            return (T) formatter.Deserialize(ref reader);
        }

        public static byte[] LZ4Serialize<T>(T value)
        {
            var writer = BinaryBufferWriter.GetWriter();
            var formatter = StandardResolver<T>.GetFormatter();
            formatter.Serialize(ref writer, value);

            return LZ4Pickler.Pickle(writer.ToArray());
        }

        public static T LZ4Deserialize<T>(byte[] bin)
        {
            var reader = new BinaryBufferReader(LZ4Pickler.Unpickle(bin));
            var formatter = StandardResolver<T>.GetFormatter();
            return (T) formatter.Deserialize(ref reader);
        }
    }
}