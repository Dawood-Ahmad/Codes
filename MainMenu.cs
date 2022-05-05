using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
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

    public void Play()
    {
        LoadScene();
    }

    public void PrivacyPolicy()
    {
        Application.OpenURL("");
    }


    public void MoreGames()
    {
        Application.OpenURL("");
    }


    public void RateUs()
    {
        Application.OpenURL("");
    }

    void LoadScene()
    {
        loadingPanel.SetActive(true);
        StartCoroutine(LoadSceneAsync("LevelSelection"));
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
