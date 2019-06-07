using System;
using System.Linq.Expressions;

namespace Ew.Runtime.Serialization.Internal
{
    public class CastTo<TTo>
    {
        public static TTo From<TFrom>(TFrom s)
        {
            return Cache<TFrom>.Caster(s);
        }    

        private static class Cache<TFrom>
        {
            public static readonly Func<TFrom, TTo> Caster = Get();

            private static Func<TFrom, TTo> Get()
            {
                var p = Expression.Parameter(typeof(TFrom));
                var c = Expression.ConvertChecked(p, typeof(TTo));
                return Expression.Lambda<Func<TFrom, TTo>>(c, p).Compile();
            }
        }
    }
}