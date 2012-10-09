using System;
using Testable;

namespace Tests {
    public class FakeComponent : Testable.TestableComponent {
        public TestableGameObject obj;

        public FakeComponent(TestableGameObject obj) : base(obj) {
            this.obj = obj;
        }


    }
}

