using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Ew.Runtime.Serialization.Attributes;
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
            var adapters = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.GetCustomAttribute(typeof(IgnoreMemberAttribute)) == null)
                .Select(p => new PropertyAdapter<T>(p)).ToArray();

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
                var ret = Expression.Convert(call, typeof(IDynamicBinaryFormatable));

                var lambda = Expression.Lambda<Func<IDynamicBinaryFormatable>>(ret);
                var formatter = lambda.Compile()();

                formatters[i] = formatter;
            }
            
            return new StandardFormatter<T>(formatters, adapters);
        }
    }
}