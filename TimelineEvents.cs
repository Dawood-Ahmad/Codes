using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimelineEvents : MonoBehaviour
{

    public UnityEvent startEvents, endEvents;

    private void OnEnable()
    {
        startEvents.Invoke();
    }


    private void OnDisable()
    {
        endEvents.Invoke();
    }
}
