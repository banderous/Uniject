using System;
using UnityEngine;

namespace Testable {
    public class UnityPhysics : IPhysics {
        public TestableGameObject[] OverlapSphere(UnityEngine.Vector3 position, float radius, int layerMask) {
            throw new Exception();
        }
    }
}
