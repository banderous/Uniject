using System;
using UnityEngine;

namespace Testable {
    public interface IPhysics {
        TestableGameObject[] OverlapSphere(Vector3 position, float radius, int layerMask);
    }
}
