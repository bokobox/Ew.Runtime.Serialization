using AutoFixture.NUnit3;
using NUnit.Framework;

namespace Ew.Runtime.Serialization.Test
{
    public class Dev
    {
        [Test]
        [AutoData]
        public void Test(bool[][] value)
        {
            var bin = BinarySerializer.Serialize(value);
            var val = BinarySerializer.Deserialize<bool[][]>(bin);
        }
    }
}