using Ew.Runtime.Serialization.Binary.Factory;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Resolvers
{
    public static class PrimitiveResolver<T>
    {
        private static BinaryFormatter<T> _formatter;

        public static bool TryGetFormatter(out IDynamicBinaryFormatable formatter)
        {
            formatter = (IDynamicBinaryFormatable) (_formatter ?? (_formatter = PrimitiveFormatterFactory.Build<T>()));
            return _formatter != null;
        }
    }
}