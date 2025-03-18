using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private AlarmTrigger _alarmTrigger;
    [SerializeField] private Alarm _alarm;

    private void OnEnable()
    {
        _alarmTrigger.OnPreferStart += _alarm.StartVolumeFade;
        _alarmTrigger.OnPreferStop += _alarm.StopVolumeFade;
    }

    private void OnDisable()
    {
        _alarmTrigger.OnPreferStop -= _alarm.StopVolumeFade;
        _alarmTrigger.OnPreferStop -= _alarm.StopVolumeFade;
    }
}