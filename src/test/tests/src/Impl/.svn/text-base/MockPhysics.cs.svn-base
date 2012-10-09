using System;
using System.Linq;
using System.Collections.Generic;
using Testable;
using UnityEngine;
using Game;

namespace Tests {
    public class MockPhysics : Testable.IPhysics {

        private List<KeyValuePair<IKineticDamage, int>> entities = new List<KeyValuePair<IKineticDamage, int>>();
        private ILayerMask mapper;
        private int defaultMask;

        public MockPhysics(ILayerMask mask) {
            this.mapper = mask;
            this.defaultMask = (1 << mask.NameToLayer("Scenery")) | (1 << mask.NameToLayer("UNDEAD"));
        }

        public void addObjectInLayer(IKineticDamage damage, string layer) {
            int code = mapper.NameToLayer(layer);
            entities.Add(new KeyValuePair<IKineticDamage, int>(damage, 1 << code));
        }

        public int OverlapSphere(ref IKineticDamage[] result, Vector3 point, float searchRadius, int livingMask) {

            result[0] = entities.FirstOrDefault(k => ((k.Value & livingMask) != 0) && k.Key.currentlyDamageable()).Key;
            return result[0] == null ? 0 : 1;
        }

        public IRepairable repairable;

        public IRepairable GetRepairables(Vector3 point, float radius) {
            return repairable;
        }

        public bool raycastResult;
        public bool Raycast(Vector3 position, Vector3 forward, out RaycastHit rHit, float maxRange, int mask) {
            rHit = new RaycastHit ();
            return raycastResult;
        }

        public IKineticDamage traceRayToDamageable(Vector3 origin, Vector3 direction, out RaycastHit hit) {
            return entities.FirstOrDefault(k => (k.Value & defaultMask) != 0).Key;
        }
    }
}

