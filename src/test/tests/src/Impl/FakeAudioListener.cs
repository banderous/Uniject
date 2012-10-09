using System;
using Testable;

namespace Tests {
    public class FakeAudioListener : TestableComponent, IAudioListener {

        public FakeAudioListener(TestableGameObject obj) : base(obj) { }

        public void noOp() {
        }
    }
}

