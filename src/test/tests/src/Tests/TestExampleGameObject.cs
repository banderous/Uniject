using Ninject;
using NUnit.Framework;
using System;
using UnityEngine;

namespace Tests {

    [TestFixture]
    public class TestExampleGameObject : BaseInjectedTest {

        [Test]
        public void testTestableExampleObjectResetsToOriginBelow100Metres() {
            TestableExample example = kernel.Get<TestableExample>();

            example.Obj.transform.Position = new Vector3(0, -101, 0);
            step(1);
            Assert.AreEqual(Vector3.zero, example.Obj.transform.Position);
        }
    }
}

