using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmAudioClip;
    [SerializeField] private float _volumeFadeSpeed = 0.5f;
    [SerializeField] private float _targetMaxVolume = 1f;
    [SerializeField] private float _targetMinVolume = 0f;

    private Coroutine _coroutine;
    
    public void StartVolumeFade()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        
       _coroutine = StartCoroutine(FadeIn(_volumeFadeSpeed, _targetMaxVolume));
    }

    public void StopVolumeFade()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
        
        _coroutine = StartCoroutine(FadeIn(_volumeFadeSpeed, _targetMinVolume));
    }

    private IEnumerator FadeIn(float fadeSpeed, float targetVolume)
    {
        if (_alarmAudioClip.isPlaying == false)
        {
            _alarmAudioClip.Play();
        }
        
        while (Mathf.Approximately(targetVolume, _alarmAudioClip.volume) == false)
        {
            _alarmAudioClip.volume =
                Mathf.MoveTowards(_alarmAudioClip.volume, targetVolume, fadeSpeed * Time.deltaTime);

            yield return null;
        }

        if (_alarmAudioClip.volume <= 0)
        {
            _alarmAudioClip.Stop();
        }
    }
}