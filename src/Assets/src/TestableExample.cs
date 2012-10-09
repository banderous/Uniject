using UnityEngine;
using System.Collections;
using Testable;

/*
 * Sample testable component that has a rigid body and sphere collider,
 * that will reset its location to the origin if it falls below -100 on the y axis.
 * 
 * The GameObjectBoundary attribute signifies that this should get its own GameObject, rather
 * than sharing that of the request scope.
 */
[GameObjectBoundary]
public class TestableExample : TestableComponent {

    private ISphereCollider collider;
    private IRigidBody body;

    public TestableExample(TestableGameObject parent, ISphereCollider collider, IRigidBody body) : base(parent) {
        this.collider = collider;
        this.body = body;

        this.collider.radius = 5.0f;
        this.body.mass = 4.0f;
    }

    public override void Update() {
        if (Obj.transform.Position.y < -100) {
            Obj.transform.Position = Vector3.zero;
        }
    }
}
