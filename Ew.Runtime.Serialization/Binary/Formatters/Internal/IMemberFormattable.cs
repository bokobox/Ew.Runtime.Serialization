using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Internal
{
    public interface IMemberFormattable<T>
    {
        void Serialize(ref InternalBufferWriter writer, T instance);

        void Deserialize(ref InternalBufferReader reader, T instance);
    }
}