using System;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class DateTimeOffsetFormatter : BinaryFormatter<DateTimeOffset>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (DateTimeOffset) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override unsafe void Serialize(ref BinaryBufferWriter writer, DateTimeOffset value)
        {
            var size = sizeof(DateTimeOffset);
            writer.Append(value, size).Size(size);
        }

        public override DateTimeOffset Deserialize(ref BinaryBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<DateTimeOffset>(size);
        }
    }
}