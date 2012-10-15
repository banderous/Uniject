using System;
using Testable;

public class TestableCollisionDetecting : TestableComponent {

    private ILogger logger;

    public TestableCollisionDetecting(TestableGameObject parent, ISphereCollider collider, IRigidBody body,
                                      IResourceLoader loader, ILogger logger) : base(parent) {
        loader.instantiate("Sphere").transform.Parent = this.Obj.transform;
        collider.radius = 0.5f;
        this.logger = logger;
    }

    public override void OnTriggerEnter(ICollider collider) {
        logger.Log("Die");
        Obj.Destroy();
    }
}
