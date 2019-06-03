using Ew.Runtime.Serialization.Binary.Interface;

namespace Ew.Runtime.Serialization.Binary
{
    public static class FormatterStore<T>
    {
        private static readonly BinaryFormatter<T> Formatter;

        static FormatterStore()
        {
            Formatter = FormatterActivator.GetFormatter<T>();
        }
        
        public static BinaryFormatter<T> GetFormater()
        {
            return Formatter;
        }
        
        public static bool TryGetFormater(out BinaryFormatter<T> formatter)
        {
            formatter = Formatter;
            return formatter != null;
        }
    }
}