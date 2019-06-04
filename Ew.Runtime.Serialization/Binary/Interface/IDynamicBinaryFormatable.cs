namespace Ew.Runtime.Serialization.Binary.Interface
{
    public interface IDynamicBinaryFormatable
    {
        void Serialize(ref BinaryBufferWriter writer, object value);
        object Deserialize(ref BinaryBufferReader reader);
    }
}