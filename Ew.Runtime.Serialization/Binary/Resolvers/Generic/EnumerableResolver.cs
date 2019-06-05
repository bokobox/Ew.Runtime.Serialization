using System.Collections;
using System.Linq;
using Ew.Runtime.Serialization.Binary.Factory.Generic;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Resolvers.Generic
{
    public static class EnumerableResolver<T>
    {
        private static IDynamicBinaryFormatable _formatable;

        public static bool TryGetFormatter(out IDynamicBinaryFormatable formatter)
        {
            formatter = null;
            if (typeof(T).GetInterfaces().All(x => x != typeof(IEnumerable)))
                return false;

            formatter = _formatable ?? (_formatable = EnumerableFormatterFactory.Build<T>());
            return true;
        }
    }
}