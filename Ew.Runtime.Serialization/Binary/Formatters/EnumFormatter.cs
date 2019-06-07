using System;
using System.Globalization;
using Ew.Runtime.Serialization.Binary.Formatters.Primitive;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters
{
    public class EnumFormatter<T> : BinaryFormatter<T>, IDynamicBinaryFormatable
    {
        private readonly IntFormatter _innerFormatter = new IntFormatter();
        
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (T)value);
        }

        public override void Serialize(ref BinaryBufferWriter writer, T value)
        {
            var num = ((IConvertible)value).ToInt32(new NumberFormatInfo());
            _innerFormatter.Serialize(ref writer, num);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override T Deserialize(ref BinaryBufferReader reader)
        {
            var num = _innerFormatter.Deserialize(ref reader);
            return CastTo<T>.From(num);
        }
    }
}