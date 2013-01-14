using System;

namespace Uniject {
    public class TestableComponent {
        private TestableGameObject obj;

        public bool enabled { get; set; }
        private bool hadFirstUpdate = false;

        public TestableComponent(TestableGameObject obj) {
            this.enabled = true;
            this.obj = obj;
            obj.registerComponent(this);
        }
        
        public TestableGameObject Obj {
            get { return obj; } 
        }

        public void OnUpdate() {
            if (enabled) {
                if (!hadFirstUpdate) {
                    hadFirstUpdate = true;
                    Start();
                }
                Update();
            }
        }

        public virtual void Start() {
        }

        public virtual void Update() {
        }

        public virtual void OnDestroy() {
        }

        public virtual void OnCollisionEnter(Collision collision) {
        }
    }
}

