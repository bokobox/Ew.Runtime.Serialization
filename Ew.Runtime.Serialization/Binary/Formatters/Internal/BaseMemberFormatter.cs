using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Internal
{
    public abstract class BaseMemberFormatter<T>
    {
        public abstract void Serialize(ref InternalBufferWriter writer, T instance);

        public abstract void Deserialize(ref InternalBufferReader reader, T instance);
    }
}