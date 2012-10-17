using System;
using UnityEngine;
using Testable;

namespace Tests {
    public class FakeAudioSource : Testable.TestableComponent, Testable.IAudioSource {

        public FakeAudioSource(TestableGameObject obj) : base(obj) {
        }

        public void playOneShot(AudioClip clip) {
        }

        public void loopSound(AudioClip clip) {
        }

        public void Play() {
        }

        public bool isPlaying { get; set; }
    }
}

