using AutoFixture.NUnit3;
using NUnit.Framework;

namespace Ew.Runtime.Serialization.Test
{
    public class Dev
    {
        [Test]
        [AutoData]
        public void Test(string value)
        {
            var bin = BinarySerializer.Serialize(value);
            var val = BinarySerializer.Deserialize<string>(bin);

            var bin2 = BinarySerializer.Serialize(true);
            var val2 = BinarySerializer.Deserialize<bool>(bin);

            var bin3 = BinarySerializer.Serialize(1234);
            var val3 = BinarySerializer.Deserialize<int>(bin);
        }
    }
}