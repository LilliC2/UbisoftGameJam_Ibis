using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioClip anxiousClockTickling;
    public AudioClip dropTrash;
    public AudioClip[] femaleScreams;
    public AudioClip[] maleScreams;
    public AudioClip hitPlayer;
    public AudioClip ibisHonk;
    public AudioClip knockOverBin;
    public AudioClip pickUpTrash;
    public AudioClip throwTrash;
    public AudioClip trashInBin;
    public AudioClip confirmButton;

    
    /// <summary>
    /// Plays an Audio Clip at set volume
    /// </summary>
    /// <param name="_clip">The clip to play</param>
    /// <param name="_source">the audio source to play on</param>
    public void PlaySound(AudioClip _clip, AudioSource _source, float _volume = 1)
    {
        if (_source == null || _clip == null)
            return;

        _source.clip = _clip;
        _source.volume = _volume;
        _source.Play();
    }
}
