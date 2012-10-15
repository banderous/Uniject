using System;
using Testable;

public class Bot : TestableComponent {

    public INavmeshAgent Agent { get; private set; }

    public Bot(TestableGameObject obj, INavmeshAgent agent, [UnityModule.PrefabAttribute("Sphere")] TestableGameObject sphere) : base(obj) {
        this.Agent = agent;
        agent.onPlacedOnNavmesh();

        sphere.transform.Parent = obj.transform;
        agent.setDestination(obj.transform.Position + obj.transform.Forward * 5);
    }
}
