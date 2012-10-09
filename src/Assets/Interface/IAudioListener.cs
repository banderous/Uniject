using System;

namespace Testable {
    public interface IAudioListener {
        void noOp();
        TestableGameObject Obj { get; }
    }
}

