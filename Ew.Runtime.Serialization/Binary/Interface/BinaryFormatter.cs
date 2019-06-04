namespace Ew.Runtime.Serialization.Binary.Interface
{
    public abstract class BinaryFormatter<T>
    {
        public abstract void Serialize(ref BinaryBufferWriter writer, T value);
        public abstract T Deserialize(ref BinaryBufferReader reader);
    }
}