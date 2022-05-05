using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Activity : MonoBehaviour
{

    public UnityEvent events;
    // Start is called before the first frame update
    void Start()
    {
        events.Invoke();
    }

}
