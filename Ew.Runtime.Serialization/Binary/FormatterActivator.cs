using Ew.Runtime.Serialization.Binary.Formatters;
using Ew.Runtime.Serialization.Binary.Formatters.Primitive;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary
{
    public static class FormatterActivator
    {
        public static IBinaryFormatable<T> GetFormatter<T>()
        {
            if (typeof(T) == typeof(string))
                return (dynamic)new StringFormatter();
            
            if (typeof(T) == typeof(bool))
                return (dynamic)new BoolFormatter();

            return null;
        }
    }
}