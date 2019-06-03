using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Interface
{
    public interface IDynamicBinaryFormatable
    {
        void Serialize(ref InternalBufferWriter writer, object value);
        object Deserialize(ref InternalBufferReader reader);
    }
}