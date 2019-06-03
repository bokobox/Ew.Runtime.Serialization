using System.Collections.Generic;
using System.Linq;
using Ew.Runtime.Serialization.Binary.Formatters.Internal;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;
using Ew.Runtime.Serialization.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters
{
    public class StandardFormatter<T> : IBinaryFormatable<T>, IDynamicBinaryFormatable
    {

        private readonly IMemberFormattable<T>[] _formatters;

        public StandardFormatter(IMemberFormattable<T>[] formatters)
        {
            _formatters = formatters;
        }

        public void Serialize(ref InternalBufferWriter writer, T instance)
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
            
            var instance = (T)InstanceActivator.GetInstance(typeof(T));
            for (var i = _formatters.Length - 1; i >= 0; i--)
                _formatters[i].Deserialize(ref reader, instance);

            return instance;
        }
    }
}