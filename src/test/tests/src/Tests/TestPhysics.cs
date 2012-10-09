using System;
using Ninject;
using Game;
using UnityEngine;
using Testable;
using NUnit.Framework;

namespace Tests {
    public class TestPhysics : BaseInjectedTest {

        [Test]
        public void testNavDoesNotReturnPathWithoutLineOfSight() {

            prepDependencies(true);
        
            NavigationUtil util = kernel.Get<NavigationUtil>();
            Assert.IsNull(util.findDamageableInRadiusWithLineOfSightPath(Vector3.zero, 10, kernel.Get<ILayerMask>().NameToLayer("UNDEAD")));
        }

        [Test]
        public void testNavReturnsPathWithLineOfSight() {
            prepDependencies(false);
            NavigationUtil util = kernel.Get<NavigationUtil>();
            Assert.IsNotNull(util.findDamageableInRadiusWithLineOfSightPath(Vector3.zero, 10, 1 << kernel.Get<ILayerMask>().NameToLayer("UNDEAD")));
        }

        private void prepDependencies(bool blocked) {
            FakePathfinder finder = (FakePathfinder) kernel.Get<IPathfinder>();
            finder.result = new Vector3[] { Vector3.zero, Vector3.one };

            MockPhysics physics = (MockPhysics) kernel.Get<IPhysics>();
            physics.addObjectInLayer(new FakeDamageable(), "UNDEAD"); 
            physics.raycastResult = blocked;
        }
    }
}

