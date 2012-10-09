using System;
using UnityEngine;

public class UnityAudioSource : Testable.IAudioSource {
	private AudioSource source;
	public UnityAudioSource(GameObject obj) {
        this.source = obj.GetComponent<AudioSource>();
        if (this.source == null) {
            this.source = (AudioSource)obj.AddComponent(typeof(AudioSource));
        }
        source.rolloffMode = AudioRolloffMode.Linear;
	}

    public void loopSound(AudioClip clip) {
        source.loop = true;
        source.clip = clip;
        source.Play();
    }

    public void playOneShot(AudioClip clip) {
        source.PlayOneShot(clip);
    }

	#region IAudioSource implementation
	public void Play ()
	{
		source.Play();
	}
	#endregion
}
