using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public GameObject buttons;


    private void Awake()
    {
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <= PlayerPrefsManager.unlockedActivityPrefs; i++)
        {
            buttons.transform.GetChild(i).gameObject.GetComponent<Button>().interactable = true;
            buttons.transform.GetChild(i).GetChild(0).gameObject.SetActive(false);
        }
        if (SoundHandler.instance.IsMusicPlaying())
        {
            SoundHandler.instance.PlayMenuMusic();
            audioButton.image.sprite = SoundHandler.instance.soundOnImg;
        }
        else
        {
            audioButton.image.sprite = SoundHandler.instance.soundOffImg;
        }
        
    }


    public void Play(int n)
    {
        PlayerPrefsManager.activityPrefs = n;
        LoadScene("GamePlay");
    }

    public void back()
    {
        LoadScene("MainMenu");
    }

    void LoadScene(string scene)
    {
        loadingPanel.SetActive(true);
        StartCoroutine(LoadSceneAsync(scene));
    }

    public GameObject loadingPanel;
    public Slider loadingBar;

    IEnumerator LoadSceneAsync(string name)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(name);
        while (!async.isDone)
        {
            loadingBar.value = async.progress;
            yield return null;
        }
        yield return null;
    }

    public Button audioButton;
    public void AudioButtonFunction()
    {
        if (SoundHandler.instance.ToggleMusic())
        {
            audioButton.image.sprite = SoundHandler.instance.soundOnImg;
        }
        else
        {
            audioButton.image.sprite = SoundHandler.instance.soundOffImg;
        }
    }


}
