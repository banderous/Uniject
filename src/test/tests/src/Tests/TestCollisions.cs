using Ninject;
using NUnit.Framework;
using System;
using UnityEngine;

namespace Tests {
    
    [TestFixture]
    public class TestCollisions : BaseInjectedTest {
        
        [Test]
        public void testExample() {
            kernel.Get<TestableCollisions>();
        }
    }
}