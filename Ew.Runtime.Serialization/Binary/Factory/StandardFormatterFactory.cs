using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Ew.Runtime.Serialization.Binary.Formatters;
using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary.Factory
{
    public static class StandardFormatterFactory
    {
        public static BinaryFormatter<T> Build<T>()
        {
            var formatters = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(x => x.GetCustomAttribute(typeof(IgnoreDataMemberAttribute)) == null)
                .Select(BuildMemberFormatter<T>)
                .ToArray();

            return new StandardFormatter<T>(formatters);
        }

        private static BaseMemberFormatter<T> BuildMemberFormatter<T>(PropertyInfo info)
        {
            var constructorInfo = typeof(MemberFormatter<,>)
                .MakeGenericType(typeof(T), info.PropertyType)
                .GetConstructor(new[] {typeof(PropertyInfo)});

            return (BaseMemberFormatter<T>) constructorInfo?.Invoke(new[] {(object) info});
        }
    }
}