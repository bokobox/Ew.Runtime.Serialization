namespace Ew.Runtime.Serialization.Binary.Interface
{
    public interface IBinaryFormatable<T>
    {
        byte[] Serialize(T value);
        T Deserialize(byte[] bin);
    }
}