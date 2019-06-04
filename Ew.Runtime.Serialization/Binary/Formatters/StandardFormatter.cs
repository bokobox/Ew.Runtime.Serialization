using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters
{
    public class StandardFormatter<T> : BinaryFormatter<T>, IDynamicBinaryFormatable
    {
        private readonly BaseMemberFormatter<T>[] _formatters;

        public StandardFormatter(BaseMemberFormatter<T>[] formatters)
        {
            _formatters = formatters;
        }

        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (T) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override void Serialize(ref BinaryBufferWriter writer, T instance)
        {
            if (instance == null)
            {
                writer.Size(0);
                return;
            }

            foreach (var t in _formatters)
                t.Serialize(ref writer, instance);

            writer.Size(1);
        }

        public override T Deserialize(ref BinaryBufferReader reader)
        {
            var count = reader.Size();
            if (count == 0)
                return default;

            var instance = InstanceActivator<T>.GetInstance();
            for (var i = _formatters.Length - 1; i >= 0; i--)
                _formatters[i].Deserialize(ref reader, instance);

            return instance;
        }
    }
}