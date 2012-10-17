using System;
using UnityEngine;

namespace Testable {
    public interface IAudioSource {
        void Play();
        void loopSound(AudioClip clip);
        void playOneShot(AudioClip clip);

        bool isPlaying { get; }
    }

}
