using System;
using Ew.Runtime.Serialization.Binary.Factory;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Resolvers
{
    public static class EnumResolver<T>
    {
        private static BinaryFormatter<T> _formatter;

        public static bool TryGetFormatter(out IDynamicBinaryFormatable formatter)
        {
            formatter = (IDynamicBinaryFormatable) (_formatter ?? (_formatter = (BinaryFormatter<T>) EnumFormatterFactory.Build<T>()));
            return typeof(T).IsEnum && _formatter != null;
        }
    }
}