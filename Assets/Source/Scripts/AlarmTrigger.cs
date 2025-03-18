using System;
using UnityEngine;

public class AlarmTrigger : MonoBehaviour
{
    public event Action OnPreferStart;
    public event Action OnPreferStop;

    private void OnTriggerEnter(Collider other)
    {
        OnPreferStart?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnPreferStop?.Invoke();
    }
}