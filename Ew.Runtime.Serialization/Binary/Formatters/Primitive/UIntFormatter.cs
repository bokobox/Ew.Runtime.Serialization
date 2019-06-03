using System;
using System.Runtime.CompilerServices;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class UIntFormatter : BinaryFormatter<uint>, IDynamicBinaryFormatable
    {
        public override void Serialize(ref InternalBufferWriter writer, uint value)
        {
            const int size = sizeof(uint);
            writer.Append(value, size).Size(size);
        }

        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (uint)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override uint Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<uint>(size);
        }
    }
}