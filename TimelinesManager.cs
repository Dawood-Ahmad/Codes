using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public class TimelinesManager : MonoBehaviour
{
    public PlayableDirector director;
    public TimelineAsset[] timelines;
    public TimelinesData timelineNumber;

    #region Singleton
    public static TimelinesManager instance;

    public void Instantiate()
    {
        instance = this;
    }
    #endregion
    private void Awake()
    {
        Instantiate();
    }

    public void PlayTimeline(int num)
    {
        director.Play(timelines[num]);
    }

    public void SkipTimeline()
    {
        director.time = director.duration - 0.1f;
    }
    public GameObject[] TimelineToggleItems;
    public GameObject[] TimelineTurnOffItems;
    public void TimelineIsRunning(bool running)
    {
        foreach(GameObject thing in TimelineToggleItems)
        {
            thing.SetActive(running);
        }

        foreach (GameObject thing in TimelineTurnOffItems)
        {
            thing.SetActive(!running);
        }
    }




}




public enum TimelinesData
{
    Level1StartingTimeline,
    Level1AskingDoctor,
    Level1EndingTimeline,
    Level2StartingTimeline,
    Level2EndingTimeline,
    Level3StartingTimeline,
    Level3WakingHusbandUp,
    Level3GivingFood,
    Level3Vomiting,
    Level4StartingTimeline,
    Level4Vomiting,
    Level4EndingTimeline,
    Level5StartingTimeline,
    Level5TalkingToTheDoctor,
    Level5EndingTimeline,
    Level6StartingTimeline,
    Level6TalkingToMidwife,
    Level7StartingTimeline,
    Level7LamazeClass,
    Level8StartingTimeline,
    Level8MidwifeComing,
    Level8GettingChecked,
    Level9StartingTimeline,
    Level9TalkingToTheNurse,
    Level10StartingTimeline,
    Level10PayingMoney,
    Level11StartingTimeline,
    Level11TalkingToNurse,
    Level11GettingTested,
    Level12StartingTimeline,
    Level12EveryoneWelcoming,
    Level12GenderReveal,
    Level12Leaving,
    Level13StartingTimeline,
    Level13TalkingToTheNurse,
    Level13EndingTimeline,
    Level14StartingTimeline,
    Level14EndingTimeline,
    Level15StartingTimeline,
    Level15SmellyBaby,
    Level15HungryThinking,
    Level15EndingTimeline,


}