using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Ew.Runtime.Serialization.Internal
{
    public class PropertyAdapter<T>
    {
        private readonly Func<object, object> _getter;
        private readonly Action<object, object> _setter;

        public PropertyAdapter(PropertyInfo info)
        {
            PropertyType = info.PropertyType;
            _getter = BuildGetter(typeof(T), info);
            _setter = BuildSetter(typeof(T), info);
        }

        public Type PropertyType { get; }

        public object Get(T instance)
        {
            return _getter(instance);
        }

        public void Set(T instance, object value)
        {
            _setter(instance, value);
        }

        private static Func<object, object> BuildGetter(Type parentType, PropertyInfo info)
        {
            var t = Expression.Parameter(typeof(object), "instance");
            var cast = parentType.IsValueType ? Expression.Unbox(t, parentType) : Expression.Convert(t, parentType);
            var accessor = Expression.PropertyOrField(cast, info.Name);
            var ret = Expression.Convert(accessor, typeof(object));
            var lambda = Expression.Lambda<Func<object, object>>(ret, t);
            return lambda.Compile();
        }

        private static Action<object, object> BuildSetter(Type parentType, PropertyInfo info)
        {
            var t = Expression.Parameter(typeof(object), "instance");
            var param = Expression.Parameter(typeof(object), "value");
            var cast = parentType.IsValueType ? Expression.Unbox(t, parentType) : Expression.Convert(t, parentType);
            var castParam = info.PropertyType.IsValueType
                ? Expression.Unbox(param, info.PropertyType)
                : Expression.Convert(param, info.PropertyType);
            var accessor = Expression.PropertyOrField(cast, info.Name);
            var assign = Expression.Assign(accessor, castParam);
            var lambda = Expression.Lambda<Action<object, object>>(assign, t, param);
            return lambda.Compile();
        }
    }
}