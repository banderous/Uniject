using System;
using UnityEngine;

namespace Testable {
    public class UnitySphereCollider : ISphereCollider {
        private SphereCollider collider;
        public UnitySphereCollider(GameObject obj) {
            this.collider = obj.AddComponent<SphereCollider>();
        }

        public float radius {
            get { return collider.radius; }
            set { collider.radius = value; }
        }

        public bool enabled {
            get { return collider.enabled; }
            set { collider.enabled = value; }
        }

        public Vector3 center {
            get { return collider.center; }
            set { collider.center = value; }
        }
    }
}

