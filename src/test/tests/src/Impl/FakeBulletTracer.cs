using System;
using UnityEngine;
using Testable;

namespace Tests {
    public class FakeBulletTracer : TestableComponent, Game.IBulletTracer {
        public FakeBulletTracer(TestableGameObject parent) : base(parent) {
        }
         public void render(Vector3 origin, Vector3 end) { }
    }
}

