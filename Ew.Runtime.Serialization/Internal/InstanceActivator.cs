using System;
using System.Linq.Expressions;

namespace Ew.Runtime.Serialization.Internal
{
    internal static class InstanceActivator<T>
    {
        private static Func<T> _activator;

        public static T GetInstance()
        {
            if (_activator == null)
                _activator = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
            
            return _activator();
        }
    }
}