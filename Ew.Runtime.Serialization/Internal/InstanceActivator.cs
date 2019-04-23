using System;
using System.Linq.Expressions;

namespace Ew.Runtime.Serialization.Internal
{
    internal static class InstanceActivator
    {
        private static ThreadSafeHashTypeTable<Func<object>> _activator;

        static InstanceActivator()
        {
            _activator = new ThreadSafeHashTypeTable<Func<object>>();
        }

        public static object GetInstance(Type type)
        {
            var activators = _activator ?? (_activator = new ThreadSafeHashTypeTable<Func<object>>());

            if (activators.TryGetValue(type, out var activator))
                return activator();

            activator = Expression.Lambda<Func<object>>(Expression.New(type)).Compile();

            activators.Add(type, activator);
            return activator();
        }
    }
}