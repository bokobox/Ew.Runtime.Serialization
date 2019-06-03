using Ew.Runtime.Serialization.Binary.Factory;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Resolvers
{
    public static class CollectionResolver<T>
    {
        private static IDynamicBinaryFormatable _formatable;

        public static IDynamicBinaryFormatable GetFormatter()
        {
            return _formatable ?? (_formatable = CollectionFormatterFactory.Build<T>());
        }
    }
}