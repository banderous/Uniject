using System;
using Testable;

namespace Tests {
	public class FakeInjectableGameObject {
		public TestableGameObject obj;
		public FakeInjectableGameObject(TestableGameObject obj, IRigidBody body, IAudioSource audio) {
			this.obj = obj;
		}
	}
}

