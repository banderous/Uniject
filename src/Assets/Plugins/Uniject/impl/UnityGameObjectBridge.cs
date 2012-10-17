using System;
using UnityEngine;

public class UnityGameObjectBridge : MonoBehaviour {
    public void OnDestroy() {
        wrapping.Destroy();
    }

    public void Update() {
        wrapping.Update();
    }

    public void OnCollisionEnter(Collision c) {
        UnityGameObjectBridge other = c.gameObject.GetComponent<UnityGameObjectBridge>();
        if (null != other) {
            Testable.Collision testableCollision =
                new Testable.Collision(c.relativeVelocity,
                                       other.wrapping.transform,
                                       other.wrapping,
                                       c.contacts);
            wrapping.OnCollisionEnter(testableCollision);
        }
    }

    public UnityGameObject wrapping;
}

