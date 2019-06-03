using System;
using System.Runtime.CompilerServices;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class IntFormatter : BinaryFormatter<int>, IDynamicBinaryFormatable
    {
        public override void Serialize(ref InternalBufferWriter writer, int value)
        {
            const int size = sizeof(int);
            writer.Append(value, size).Size(size);
        }

        void IDynamicBinaryFormatable.Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (int)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public override int Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<int>(size);
        }
    }
}