using System.Collections;
using System.Linq;
using Ew.Runtime.Serialization.Binary.Factory;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Resolvers
{
    public static class ArrayResolver<T>
    {
        private static IDynamicBinaryFormatable _formatable;

        public static bool TryGetFormatter(out IDynamicBinaryFormatable formatter)
        {
            formatter = null;
            if (!typeof(T).IsArray)
                return false;

            formatter = _formatable ?? (_formatable = ArrayFormatterFactory.Build<T>());
            return true;
        }
    }
}