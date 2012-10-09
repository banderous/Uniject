using System;
using UnityEngine;

public class UnityGameObjectBridge : MonoBehaviour {
    public void OnDestroy() {
        wrapping.Destroy();
    }

    public void Update() {
        wrapping.Update();
    }

    public UnityGameObject wrapping;
}

