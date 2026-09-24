using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake() => CacheComponents();
    private void Update() => WaitForEnd();

    private void WaitForEnd()
    {
        if (_audioSource.isPlaying || _audioSource.loop) return;
        Stop();
    }

    private void CacheComponents()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public AudioPlayer SetVolume(float volume)
    {
        _audioSource.volume = volume;
        return this;
    }

    public AudioPlayer PlayOnAwake(bool playOnAwake)
    {
        _audioSource.playOnAwake = playOnAwake;
        return this;
    }

    public AudioPlayer SetLoop(bool loop)
    {
        _audioSource.loop = loop;
        return this;
    }

    public AudioPlayer SetAudioClip(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        return this;
    }

    public void Play()
    {
        _audioSource.Play();
    }

    public void Pause()
    {
        _audioSource.Pause();
    }

    public void Stop()
    {
        _audioSource.Stop();
        ReturnPool();
    }

    public void ReturnPool()
    {
        AudioManager.Instance.Return(this);
    }
}
