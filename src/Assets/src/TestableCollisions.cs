using System;
using Testable;


public class TestableCollisions {

    public TestableCollisions([GameObjectBoundary] Box box, [GameObjectBoundary] Sphere sphere,
                              [Resource("physic/bouncy")] IPhysicMaterial material) {
        box.Obj.transform.localScale = new UnityEngine.Vector3(50, 1, 50);
        sphere.collider.material = material;
        sphere.obj.transform.Translate(new UnityEngine.Vector3(0, 10, 0));
    }
}
