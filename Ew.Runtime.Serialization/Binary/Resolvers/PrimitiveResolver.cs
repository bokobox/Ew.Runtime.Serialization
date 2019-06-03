using Ew.Runtime.Serialization.Binary.Factory;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Resolvers
{
    public static class PrimitiveResolver<T>
    {
        private static IBinaryFormatable<T> _formatable;

        public static IBinaryFormatable<T> GetFormatter()
        {
            return _formatable ?? (_formatable = PrimitiveFormatterFactory.Build<T>());
        }
    }
}