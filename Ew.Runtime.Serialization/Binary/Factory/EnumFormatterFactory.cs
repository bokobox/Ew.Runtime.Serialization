using System;
using System.Linq;
using System.Reflection;
using Ew.Runtime.Serialization.Binary.Formatters;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Resolvers;

namespace Ew.Runtime.Serialization.Binary.Factory
{
    public static class EnumFormatterFactory
    {
        public static IDynamicBinaryFormatable Build<T>()
        {
            return new EnumFormatter<T>();
        }
    }
}