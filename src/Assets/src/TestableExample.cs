using UnityEngine;
using System.Collections;
using Testable;

/*
 * Sample testable component that has a rigid body and sphere collider,
 * that will reset its location to the origin if it falls below -100 on the y axis.
 * 
 * The GameObjectBoundary attribute signifies that this should get its own GameObject, rather
 * than sharing that of the request scope, which is the default.
 */
[GameObjectBoundary]
public class TestableExample : TestableComponent {

    public TestableExample(TestableGameObject parent, ISphereCollider collider, IRigidBody body,
                          [PrefabAttribute("Sphere")] TestableGameObject sphere) : base(parent) {
        sphere.transform.Parent = this.Obj.transform;

        collider.radius = 0.5f;
        body.mass = 4.0f;

        this.Obj.transform.localScale = new Vector3(5, 5, 5);
    }

    public override void Update() {
        if (Obj.transform.Position.y < -100) {
            Obj.transform.Position = Vector3.zero;
        }
    }
}
