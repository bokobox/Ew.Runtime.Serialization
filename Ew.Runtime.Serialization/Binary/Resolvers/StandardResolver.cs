using Ew.Runtime.Serialization.Binary.Factory;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Resolvers.Generic;

namespace Ew.Runtime.Serialization.Binary.Resolvers
{
    public static class StandardResolver<T>
    {
        private static BinaryFormatter<T> _formatable;

        public static BinaryFormatter<T> GetFormatter()
        {
            if (_formatable != null)
                return _formatable;

            if (PrimitiveResolver<T>.TryGetFormatter(out var formatter))
                _formatable = (BinaryFormatter<T>)formatter;
            else if (ArrayResolver<T>.TryGetFormatter(out formatter))
                _formatable = (BinaryFormatter<T>)formatter;
            else if (EnumerableResolver<T>.TryGetFormatter(out formatter))
                _formatable = (BinaryFormatter<T>)formatter;
            else if (EnumResolver<T>.TryGetFormatter(out formatter))
                _formatable = (BinaryFormatter<T>)formatter;
            else
                _formatable = StandardFormatterFactory.Build<T>();

            return _formatable;
        }
    }
}