using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{

    public static int activityPrefs
    {
        get { return PlayerPrefs.GetInt("ActivityPrefs"); }
        set { PlayerPrefs.SetInt("ActivityPrefs", value); }
    }


    public static int unlockedActivityPrefs
    {
        get { return PlayerPrefs.GetInt("unlockedActivityPrefs"); }
        set { PlayerPrefs.SetInt("unlockedActivityPrefs", value); }
    }


}
