using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;
using Ew.Runtime.Serialization.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters
{
    public class StandardFormatter<T> : IBinaryFormatable<T>
    {
        private readonly IDynamicBinaryFormatable[] _formatables;
        private readonly PropertyAdapter<T>[] _adapters;

        public StandardFormatter(IDynamicBinaryFormatable[] formatables, PropertyAdapter<T>[] adapters)
        {
            _formatables = formatables;
            _adapters = adapters;
        }

        public void Serialize(ref InternalBufferWriter writer, T instance)
        {
            if (instance == null)
            {
                writer.Size(0);
                return;
            }

            for (var i = 0; i < _adapters.Length; i++)
            {
                var adapter = _adapters[i];
                var formatter = _formatables[i];
                
                var value = adapter.Get(instance);
                formatter.Serialize(ref writer, value);
            }
            
            writer.Size(1);
        }

        public void Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (T)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public T Deserialize(ref InternalBufferReader reader)
        {
            var count = reader.Size();
            if (count == 0)
                return default;
            
            var instance = InstanceActivator.GetInstance(typeof(T));
            for (var i = _adapters.Length - 1; i >= 0; i--)
            {
                var adapter = _adapters[i];
                var formatter = _formatables[i];

                var value = formatter.Deserialize(ref reader);
                adapter.Set((T)instance, value);
            }

            return (T)instance;
        }
    }
}