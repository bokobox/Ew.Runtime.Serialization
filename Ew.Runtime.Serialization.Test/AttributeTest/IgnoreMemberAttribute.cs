using System;
using AutoFixture.NUnit3;
using NUnit.Framework;

namespace Ew.Runtime.Serialization.Test.AttributeTest
{
    public class IgnoreMemberAttribute
    {
        [Test]
        [AutoData]
        public void SerializeIgnoredMember(AttributeTestModel value)
        {
            var value2 = value;
            var bin = BinarySerializer.Serialize(value2);
            value2 = BinarySerializer.Deserialize<AttributeTestModel>(bin);

            Assert.IsFalse(EwAssert.Equal(value, value2));
            Assert.IsFalse(value.Member13 == default(DateTimeOffset));
            Assert.IsTrue(value2.Member13 == default(DateTimeOffset));

        }
        
        [Test]
        [AutoData]
        public void SerializeAndDeserializeTest(AttributeTestModel value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<AttributeTestModel>(bin);
            }

            Assert.IsFalse(EwAssert.Equal(value, value2));
        }
    }
}