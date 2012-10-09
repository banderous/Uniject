using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Game;
using UnityEngine;

namespace Tests {
    class FakeRayTracer : IRaytracer {
        public UnityEngine.Vector3 traceRay(UnityEngine.Vector3 origin, UnityEngine.Vector3 direction, int mask) {
            return new Vector3();
        }

        public UnityEngine.Vector3 traceRay(UnityEngine.Vector3 origin, UnityEngine.Vector3 direction) {
            return new Vector3();
        }

        public Testable.IKineticDamage traceRayToDamageable(UnityEngine.Vector3 origin, UnityEngine.Vector3 direction, out UnityEngine.RaycastHit hit) {
            hit = new RaycastHit();
            return null;
        }

        public bool lineOfSightBetweenPoints(Vector3 a, Vector3 b) {
            return true;
        }
    }
}
