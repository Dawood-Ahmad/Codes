using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineController : MonoBehaviour
{
    public TimelinesData timeline;



    public void PlayTimeLine()
    {
        TimelinesManager.instance.PlayTimeline(((int)timeline));
    }



}
