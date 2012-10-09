using System;
using NUnit.Framework;
using Ninject;
using Game;

namespace Tests {
    public class TestPlayer : BaseInjectedTest {

        [Test]
        public void testInstantiate() {
            kernel.Get<Player>();
        }
    }
}

