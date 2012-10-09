using System;
using Testable;
using UnityEngine;

namespace Tests {
    public class FakeSphereCollider : Testable.TestableComponent, Testable.ISphereCollider {

        public FakeSphereCollider(TestableGameObject obj) : base(obj) {
        }

        public float radius { get; set; }

        public Vector3 center { get; set; }
    }
}

