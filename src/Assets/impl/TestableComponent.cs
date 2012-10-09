using System;

namespace Testable {
    public class TestableComponent {
        private TestableGameObject obj;

        protected bool enabled { get; set; }

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
                Update();
            }
        }

        public virtual void Update() {
        }

        public virtual void OnDestroy() {
        }
    }
}

