using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Interface
{
    public interface IBinaryFormatable<T> : IDynamicBinaryFormatable
    {
        void Serialize(ref InternalBufferWriter writer, T value);
        new T Deserialize(ref InternalBufferReader reader);
    }
}