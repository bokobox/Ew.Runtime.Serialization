using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Ew.Runtime.Serialization.Binary.Formatters;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Resolvers;

namespace Ew.Runtime.Serialization.Binary.Factory
{
    public static class ArrayFormatterFactory
    {
        public static IDynamicBinaryFormatable Build<T>()
        {
            var elementType = typeof(T).GetElementType() ?? typeof(T).GetGenericArguments().First();
            var innerFormatter = GetInnerFormatter(elementType);

            var type = typeof(ArrayFormatter<>).MakeGenericType(elementType);

            var formatter = Activator.CreateInstance(type, innerFormatter);
            return (IDynamicBinaryFormatable) formatter;
        }

        private static IDynamicBinaryFormatable GetInnerFormatter(Type elementType)
        {
            const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

            var method = typeof(StandardResolver<>)
                .MakeGenericType(elementType)
                .GetMethod("GetFormatter", bindingFlags);

            if (method == null)
                throw new NullReferenceException("method is null");

            var call = Expression.Call(method);
            var ret = Expression.Convert(call, typeof(object));

            var lambda = Expression.Lambda<Func<object>>(ret);
            return (IDynamicBinaryFormatable) lambda.Compile()();
        }
    }
}