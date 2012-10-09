using System;
using UnityEngine;

namespace Tests {
    public class FakeRigidBody : Testable.TestableComponent, Testable.IRigidBody {

        public FakeRigidBody(Testable.TestableGameObject obj) : base(obj) {
        }

        public void AddForce (UnityEngine.Vector3 force) {
        }

        public float drag { get; set; }
        public float mass { get; set; }
        public bool enabled { get; set; }

        public Quaternion Rotation {
            get { return Quaternion.identity; }
            set { }
        }

        public Vector3 Position {
            get { return Obj.transform.Position; }
        }

        public Vector3 Forward {
            get { return Obj.transform.Forward; }
        }

        private RigidbodyConstraints rConstraints;

        public RigidbodyConstraints constraints {
            get { return rConstraints; }
            set { rConstraints = value; }
        }

        public bool useGravity { get; set; }
    }
}

