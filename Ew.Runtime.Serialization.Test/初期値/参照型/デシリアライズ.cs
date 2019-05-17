using Ew.Runtime.Serialization.Test.Models;
using NUnit.Framework;

namespace Ew.Runtime.Serialization.Test.初期値.参照型
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
        public void モデル1テスト()
        {
            var value = new TestModel1();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel1>(bin);
            }

            Assert.IsTrue(false);
        }

        [Test]
        public void モデル2テスト()
        {
            var value = new TestModel2();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel2>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル3テスト()
        {
            var value = new TestModel3();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel3>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル4テスト()
        {
            var value = new TestModel4();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel4>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル5テスト()
        {
            var value = new TestModel5();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel5>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル6テスト()
        {
            var value = new TestModel6();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel6>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル7テスト()
        {
            var value = new TestModel7();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel7>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル8テスト()
        {
            var value = new TestModel8();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel8>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル9テスト()
        {
            var value = new TestModel9();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel9>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル10テスト()
        {
            var value = new TestModel10();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel10>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル11テスト()
        {
            var value = new TestModel11();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel11>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル12テスト()
        {
            var value = new TestModel12();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel12>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル13テスト()
        {
            var value = new TestModel13();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel13>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル14テスト()
        {
            var value = new TestModel14();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel14>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル15テスト()
        {
            var value = new TestModel15();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel15>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル16テスト()
        {
            var value = new TestModel16();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel16>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル17テスト()
        {
            var value = new TestModel17();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel17>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル18テスト()
        {
            var value = new TestModel18();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel18>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル19テスト()
        {
            var value = new TestModel19();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel19>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル20テスト()
        {
            var value = new TestModel20();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel20>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル21テスト()
        {
            var value = new TestModel21();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel21>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル22テスト()
        {
            var value = new TestModel22();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel22>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル23テスト()
        {
            var value = new TestModel23();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel23>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル24テスト()
        {
            var value = new TestModel24();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel24>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル25テスト()
        {
            var value = new TestModel25();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel25>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル26テスト()
        {
            var value = new TestModel26();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel26>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル27テスト()
        {
            var value = new TestModel27();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel27>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル28テスト()
        {
            var value = new TestModel28();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel28>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル29テスト()
        {
            var value = new TestModel29();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel29>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル30テスト()
        {
            var value = new TestModel30();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel30>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル31テスト()
        {
            var value = new TestModel31();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel31>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル32テスト()
        {
            var value = new TestModel32();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel32>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル33テスト()
        {
            var value = new TestModel33();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel33>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル34テスト()
        {
            var value = new TestModel34();
            var value2 = value;
            for (var i = 0; i < 3; i++)
            {
                var bin = BinarySerializer.Serialize(value2);
                value2 = BinarySerializer.Deserialize<TestModel34>(bin);
            }

            Assert.IsTrue(EwAssert.Equal(value, value2));
        }

        [Test]
        public void モデル35テスト()
        {
            var value = new TestModel35();
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