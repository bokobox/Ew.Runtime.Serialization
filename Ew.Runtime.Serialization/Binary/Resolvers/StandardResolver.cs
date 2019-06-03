using Ew.Runtime.Serialization.Binary.Factory;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Resolvers
{
    public static class StandardResolver<T>
    {
        private static IDynamicBinaryFormatable _formatable;

        public static IDynamicBinaryFormatable GetFormatter()
        {
            if (_formatable == null)
            {
                var formatter = PrimitiveResolver<T>.GetFormatter();

                if (formatter == null && typeof(T).IsArray)
                    _formatable = CollectionResolver<T>.GetFormatter();

                else if (formatter == null)
                    _formatable = (IDynamicBinaryFormatable) StandardFormatterFactory.Build<T>();

                else
                    _formatable = (IDynamicBinaryFormatable) formatter;
            }

            return _formatable;
        }
    }
}