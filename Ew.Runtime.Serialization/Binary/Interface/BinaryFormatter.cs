using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Interface
{
    public abstract class BinaryFormatter<T>
    {
        public abstract void Serialize(ref InternalBufferWriter writer, T value);
        public abstract T Deserialize(ref InternalBufferReader reader);
    }
}