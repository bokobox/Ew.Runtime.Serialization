using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class DateTimeFormatter : BinaryFormatter<DateTime>, IDynamicBinaryFormatable
    {
        public override unsafe void Serialize(ref InternalBufferWriter writer, DateTime value)
        {
            var size = sizeof(DateTime);
            writer.Append(value, size).Size(size);
        }

        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (DateTime)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override DateTime Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<DateTime>(size);
        }
    }
}