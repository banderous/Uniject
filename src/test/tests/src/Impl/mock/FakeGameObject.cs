using System;
using System.Collections.Generic;
using Testable;
using UnityEngine;

namespace Tests {
    public class FakeGameObject : TestableGameObject {

        public class FakeTransform : ITransform {
   
            public bool active { get; set; }

            public Vector3 Position { get; set; }

            public Quaternion Rotation { get; set; }

            public Vector3 Forward { get; set; }

            public Vector3 Up { get; set; }

            public Vector3 TransformDirection(Vector3 dir) {
                return dir;
            }

            public void LookAt(Vector3 point) {
            }

            private ITransform t;

            public ITransform Parent {
                get {
                    return t;
                }
                set {
                    if (value == null) {
                        throw new NullReferenceException ();
                    }
                    t = value;
                }
            }

            public void Translate(Vector3 byVector) {
                this.Position += byVector;
            }
        }

        public FakeGameObject(ITransform transform, TestUpdatableManager manager) : base(transform) {
            manager.RegisterGameobject(this);
            active = true;
        }

        public override string name { get; set; }

        public override bool active { get; set; }

        public override void setActiveRecursively(bool active) {
            if (destroyed) {
                throw new Exception ("Cannot access destroyed gameobject.");
            }
            active = false;
        }

        public override int layer { get; set; }
    }
}

