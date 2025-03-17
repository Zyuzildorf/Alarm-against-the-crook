using System;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudioClip;
    [SerializeField] private float _volumeFadeRate = 0.2f;

    private float _currentVolume;
    private float _maxVolume;
    private bool _isTriggered;
    private bool _isVolumeValueChanging;

    private void Awake()
    {
        _maxVolume = _alarmAudioClip.volume;
        _currentVolume = 0f;
        _alarmAudioClip.volume = _currentVolume;
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isTriggered == false)
        {
            PlayAudioClip();
        }
        else if (_isTriggered == true)
        {
            StopAudioClip();
        }
        else
        {
            PlayAudioClip();
        }
    }

    private void PlayAudioClip()
    {
        _isTriggered = true;
        _isVolumeValueChanging = true;

        _alarmAudioClip.Play();

        _alarmAudioClip.volume = Mathf.MoveTowards(_currentVolume, _maxVolume, _volumeFadeRate * Time.deltaTime);

        if (_alarmAudioClip.volume == _maxVolume)
        {
            _isVolumeValueChanging = false;
        }
    }

    private void StopAudioClip()
    {
        _isTriggered = false;
        _isVolumeValueChanging = true;

        // while (_isVolumeValueChanging)
        {
            _alarmAudioClip.volume = Mathf.MoveTowards(_currentVolume, _maxVolume, -_volumeFadeRate * Time.deltaTime);
            if (_alarmAudioClip.volume <= 0)
            {
                _alarmAudioClip.Stop();
                _isVolumeValueChanging = false;
            }
        }
    }
}