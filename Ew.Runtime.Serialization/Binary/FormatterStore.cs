using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary
{
    public static class FormatterStore<T>
    {
        private static readonly IBinaryFormatable<T> Formatable;

        static FormatterStore()
        {
            Formatable = FormatterActivator.GetFormatter<T>();
        }
        
        public static IBinaryFormatable<T> GetFormater()
        {
            return Formatable;
        }
        
        public static bool TryGetFormater(out IBinaryFormatable<T> formatable)
        {
            formatable = Formatable;
            return formatable != null;
        }
    }
}