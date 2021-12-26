using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFX : MonoBehaviour
{
    private AudioSource audio_source;

    private void Awake()
    {
        audio_source = GetComponent<AudioSource>();
    }

    public void PlayAudioClip(AudioClip audio_clip)
    {
        if (audio_source.clip != audio_clip)
            audio_source.Stop();

        audio_source.Play();
    }

    public void StopPlayingSound()
    {
        audio_source.Stop();
    }
}