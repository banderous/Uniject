using System;
using Testable;
using UnityEngine;

namespace Tests {
  public class MockDamageable : Testable.IKineticDamage {
    public float damageDone = 0.0f;
    public void kineticDamage(Vector3 location, Vector3 incidentDirection, Vector3 normal, float amount) {
      damageDone += amount;
    }
    public Testable.TestableGameObject Obj { get { return null; } }

    public bool damageable = true;
    public bool currentlyDamageable() {
      return damageable;
    }
    public EntityType type = EntityType.NEUTRAL;
    public EntityType getType () {
      return type;
    }

    public Vector3 getLocation() {
      return Vector3.zero;
    }
  }
}

