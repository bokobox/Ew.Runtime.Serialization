using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AutoFixture.NUnit3;
using Ew.Runtime.Serialization.Test.Models;
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