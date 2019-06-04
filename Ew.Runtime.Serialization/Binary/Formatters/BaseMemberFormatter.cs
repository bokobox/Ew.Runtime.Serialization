namespace Ew.Runtime.Serialization.Binary.Formatters
{
    public abstract class BaseMemberFormatter<T>
    {
        public abstract void Serialize(ref BinaryBufferWriter writer, T instance);

        public abstract void Deserialize(ref BinaryBufferReader reader, T instance);
    }
}