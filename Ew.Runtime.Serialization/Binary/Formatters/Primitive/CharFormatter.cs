using System;
using System.Runtime.CompilerServices;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Internal;

namespace Ew.Runtime.Serialization.Binary.Formatters.Primitive
{
    public class CharFormatter : IBinaryFormatable<char>
    {
        public void Serialize(ref InternalBufferWriter writer, char value)
        {
            writer.Append(value, sizeof(char)).Size(sizeof(char));
        }

        public void Serialize(ref InternalBufferWriter writer, object value)
        {
            Serialize(ref writer, (char)value);
        }

        object IDynamicBinaryFormatable.Deserialize(ref InternalBufferReader reader)
        {
            return Deserialize(ref reader);
        }

        public char Deserialize(ref InternalBufferReader reader)
        {
            var size = reader.Size();
            return reader.Data<char>(size);
        }
    }
}