using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Ew.Runtime.Serialization.Internal
{
    internal class PropertyAdapter<TParent, TMember>
    {
        private readonly Func<TParent, TMember> _getter;
        private readonly Action<TParent, TMember> _setter;

        public PropertyAdapter(PropertyInfo info)
        {
            PropertyType = info.PropertyType;
            _getter = BuildGetter(info);
            _setter = BuildSetter(info);
        }

        public Type PropertyType { get; }

        public TMember Get(TParent instance)
        {
            return _getter(instance);
        }

        public void Set(TParent instance, TMember value)
        {
            _setter(instance, value);
        }

        private static Func<TParent, TMember> BuildGetter(PropertyInfo info)
        {
            var t = Expression.Parameter(typeof(TParent), "instance");
            var accessor = Expression.PropertyOrField(t, info.Name);
            var lambda = Expression.Lambda<Func<TParent, TMember>>(accessor, t);
            return lambda.Compile();
        }

        private static Action<TParent, TMember> BuildSetter(PropertyInfo info)
        {
            var t = Expression.Parameter(typeof(TParent), "instance");
            var param = Expression.Parameter(typeof(TMember), "value");
            var accessor = Expression.PropertyOrField(t, info.Name);
            var assign = Expression.Assign(accessor, param);
            var lambda = Expression.Lambda<Action<TParent, TMember>>(assign, t, param);
            return lambda.Compile();
        }
    }
}