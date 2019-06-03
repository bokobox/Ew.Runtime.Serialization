using System;
using System.Linq.Expressions;
using System.Reflection;
using Ew.Runtime.Serialization.Binary.Formatters;
using Ew.Runtime.Serialization.Binary.Interface;
using Ew.Runtime.Serialization.Binary.Resolvers;
using Ew.Runtime.Serialization.Internal;

namespace Ew.Runtime.Serialization.Binary.Factory
{
    public static class StandardFormatterFactory
    {
        public static IBinaryFormatable<T> Build<T>()
        {
            var adapters = AdapterStore.GetPropertyAdapters(typeof(T));

            var formatters = new IDynamicBinaryFormatable[adapters.Length];

            for (var i = 0; i < adapters.Length; i++)
            {
                var adapter = adapters[i];
                
                //Expressionで、Formatterを生成する
                const BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

                var method = typeof(StandardResolver<>)
                    .MakeGenericType(adapter.PropertyType)
                    .GetMethod("GetFormatter", bindingFlags);
                
                if (method == null)
                    throw new NullReferenceException("method is null");
                
                var call = Expression.Call(method);
                var ret = Expression.Convert(call, typeof(object));

                var lambda = Expression.Lambda<Func<object>>(ret);
                var formatter = lambda.Compile()();

                formatters[i] = (IDynamicBinaryFormatable)formatter;
            }
            
            return new StandardFormatter<T>(formatters, adapters);
        }
    }
}