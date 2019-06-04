using Ew.Runtime.Serialization.Binary.Factory;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Resolvers
{
    public static class StandardResolver<T>
    {
        private static IDynamicBinaryFormatable _formatable;

        public static IDynamicBinaryFormatable GetFormatter()
        {
            if (_formatable != null)
                return _formatable;

            if (PrimitiveResolver<T>.TryGetFormatter(out var formatter))
                _formatable = formatter;
            else if (CollectionResolver<T>.TryGetFormatter(out formatter))
                _formatable = formatter;
            else
                _formatable = (IDynamicBinaryFormatable) StandardFormatterFactory.Build<T>();

            return _formatable;
        }
    }
}