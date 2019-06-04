using System;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class DateTimeFormatter : BinaryFormatter<DateTime>, IDynamicBinaryFormatable
    {
        void IDynamicBinaryFormatable.Serialize(ref BinaryBufferWriter writer, object value)
        {
            Serialize(ref writer, (DateTime) value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref BinaryBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override unsafe void Serialize(ref BinaryBufferWriter writer, DateTime value)
        {
            var size = sizeof(DateTime);
            writer.Append(value, size).Size(size);
        }

        public override DateTime Deserialize(ref BinaryBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<DateTime>(size);
        }
    }
}