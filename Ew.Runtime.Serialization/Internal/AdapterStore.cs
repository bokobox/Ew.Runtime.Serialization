using System;
using System.Linq;
using System.Reflection;

namespace Ew.Runtime.Serialization.Internal
{
    internal static class AdapterStore
    {
        private static ThreadSafeHashTypeTable<PropertyAdapter[]> _adapters;
        private static ThreadSafeHashTypeTable<PropertyAdapter[]> _reverseAdapters;

        static AdapterStore()
        {
            _adapters = new ThreadSafeHashTypeTable<PropertyAdapter[]>();
        }

        public static PropertyAdapter[] GetPropertyAdapters(Type type, bool reverse)
        {
            if (reverse)
            {
                var adaptersList = _reverseAdapters ??
                                   (_reverseAdapters = new ThreadSafeHashTypeTable<PropertyAdapter[]>());

                if (adaptersList.TryGetValue(type, out var adapters))
                    return adapters;

                adapters = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Select(p => new PropertyAdapter(type, p)).Reverse().ToArray();

                adaptersList.Add(type, adapters);
                return adapters;
            }
            else
            {
                var adaptersList = _adapters ?? (_adapters = new ThreadSafeHashTypeTable<PropertyAdapter[]>());

                if (adaptersList.TryGetValue(type, out var adapters))
                    return adapters;

                adapters = type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Select(p => new PropertyAdapter(type, p)).ToArray();

                adaptersList.Add(type, adapters);
                return adapters;
            }
        }
    }
}