using System;
using UnityEngine;

namespace Testable {
    public class UnityAudioListener : TestableComponent, IAudioListener {

        public UnityAudioListener(TestableGameObject parent, GameObject obj) : base(parent) {
            AudioListener listener = obj.GetComponent<AudioListener>();
            if (null == listener) {
                obj.AddComponent<AudioListener>();
            }
        }

        public void noOp() {
        }
    }
}

