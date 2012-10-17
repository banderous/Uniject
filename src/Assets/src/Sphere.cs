using System;
using Testable;

public class Sphere {
    public TestableGameObject obj { get; private set; }
    public ISphereCollider collider { get; private set; }
    public Sphere(TestableGameObject obj,
                  IRigidBody body,
                  ISphereCollider collider,
                  [Resource("mesh/sphere")] TestableGameObject sphere) {
        this.obj = obj;
        this.collider = collider;
        sphere.transform.Parent = obj.transform;
    }
}
