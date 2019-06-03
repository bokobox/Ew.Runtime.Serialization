using System;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class DateTimeOffsetFormatter : BinaryFormatter<DateTimeOffset>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (DateTimeOffset) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override unsafe void Serialize(ref InternalBufferWriter writer, DateTimeOffset value)
        {
            var size = sizeof(DateTimeOffset);
            writer.Append(value, size).Size(size);
        }

        public override DateTimeOffset Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<DateTimeOffset>(size);
        }
    }
}