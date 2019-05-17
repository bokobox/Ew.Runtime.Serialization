using AutoFixture.NUnit3;
using Ew.Runtime.Serialization.Test.Models;
using NUnit.Framework;

namespace Ew.Runtime.Serialization.Test.ダミーデータ.参照型
{
    public class デシリアライズ
    {
        /*
           string
           bool
           char
           sbyte
           byte
           short
           ushort
           int
           uint
           long
           ulong
           float
           decimal
           byte[]
           DateTime
           DateTimeOffset
        */

        //3回シリアライズとデシリアライズを行い、元データと比較する

        [Test]
        [AutoData]
        public void モデル1テスト(TestModel1 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel1>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル2テスト(TestModel2 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel2>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル3テスト(TestModel3 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel3>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル4テスト(TestModel4 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel4>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル5テスト(TestModel5 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel5>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル6テスト(TestModel6 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel6>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル7テスト(TestModel7 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel7>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル8テスト(TestModel8 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel8>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル9テスト(TestModel9 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel9>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル10テスト(TestModel10 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel10>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル11テスト(TestModel11 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel11>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル12テスト(TestModel12 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel12>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル13テスト(TestModel13 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel13>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル14テスト(TestModel14 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel14>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル15テスト(TestModel15 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel15>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル16テスト(TestModel16 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel16>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル17テスト(TestModel17 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel17>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル18テスト(TestModel18 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel18>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル19テスト(TestModel19 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel19>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル20テスト(TestModel20 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel20>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル21テスト(TestModel21 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel21>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル22テスト(TestModel22 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel22>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル23テスト(TestModel23 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel23>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル24テスト(TestModel24 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel24>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル25テスト(TestModel25 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel25>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル26テスト(TestModel26 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel26>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル27テスト(TestModel27 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel27>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル28テスト(TestModel28 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel28>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル29テスト(TestModel29 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel29>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル30テスト(TestModel30 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel30>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル31テスト(TestModel31 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel31>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル32テスト(TestModel32 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel32>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル33テスト(TestModel33 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel33>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        [AutoData]
        public void モデル34テスト(TestModel34 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel34>(bin);
            }

            Assert.IsTrue(false);
        }

        [Test]
        [AutoData]
        public void モデル35テスト(TestModel35 value)
        {
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel35>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }
    }
}