using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityManager : MonoBehaviour
{

    public GameObject activitiesParent;
    GameObject[] activities;


    #region Singleton
    public static ActivityManager instance;

    public void Instanciate()
    {
        instance = this;
    }
    #endregion


    private void Awake()
    {
        Instanciate();
        
    }

    public void Initialize()
    {
        activities = new GameObject[activitiesParent.transform.childCount];
        for (int i = 0; i < activitiesParent.transform.childCount; i++)
        {
            activities[i] = activitiesParent.transform.GetChild(i).gameObject;
        }
        TurnOnCurrentActivity(PlayerPrefsManager.activityPrefs);
    }

    void TurnOnCurrentActivity(int num)
    {
        foreach(GameObject activity in activities)
        {
            activity.SetActive(false);
        }
        activities[num].gameObject.SetActive(true);
    }



}
