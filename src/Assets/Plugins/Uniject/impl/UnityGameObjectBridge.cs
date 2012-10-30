using System;
using Uniject.Impl;
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
                Uniject.Collision testableCollision =
                new Uniject.Collision(c.relativeVelocity,
                                      other.wrapping.transform,
                                      other.wrapping,
                                      c.contacts);
            wrapping.OnCollisionEnter(testableCollision);
        }
    }

    public void Start() {
        if (null == wrapping && wrapRef != null) {
            wrapping = new UnityGameObject(wrapRef);
        }
    }

    public void wrap(UnityGameObject obj) {
        this.wrapRef = obj.obj;
        this.wrapping = obj;
    }

    public UnityGameObject wrapping { get; private set; }

    [SerializeField]
    private GameObject wrapRef;
}

