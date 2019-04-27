using Newtonsoft.Json;

namespace Ew.Runtime.Serialization.Test
{
    public static class EwAssert
    {
        public static bool Equal(object obj1, object obj2)
        {
            var bin1 = JsonConvert.SerializeObject(obj1);
            var bin2 = JsonConvert.SerializeObject(obj2);

            return bin1 == bin2;
        }
    }
}