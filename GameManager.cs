using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.Cameras;
using TMPro;
using SickscoreGames.HUDNavigationSystem;

public class GameManager : MonoBehaviour
{

    public Button actionButton;
    public Button doorButton;
    public Button pickButton;
    public GameObject environment;
    [HideInInspector]public GameObject Object;
    #region Singleton
    public static GameManager instance;
    void Instanciate()
    {
        instance = this;
    }

    private GameManager() { }
    #endregion
    private void Awake()
    {
        Time.timeScale = 1;
        environment.SetActive(true);
        #region Make Singleton
        Instanciate();
        #endregion
        //PlayerPrefsManager.activityPrefs = 14;

    }

    // Start is called before the first frame update
    void Start()
    {
        ActivityManager.instance.Initialize();
        //if (SoundHandler.instance.IsMusicPlaying())
        //{
        //    SoundHandler.instance.PlayGamePlayMusic();
        //    audioButton.image.sprite = SoundHandler.instance.soundOnImg;
        //}
        //else
        //{
        //    audioButton.image.sprite = SoundHandler.instance.soundOffImg;
        //}
    }

    public GameObject loadingScreen;
    public Slider loadingBar;

    public void LoadScene(string scene)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync(scene));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {

        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(sceneName);
        while (!sceneLoading.isDone)
        {
            //make loading bar value upto 100
            loadingBar.value = sceneLoading.progress;
            yield return null;
        }

        yield return null;
    }


    void NextLevel()
    {


        // write code for unlocked activity and mode based activity



        // change the first condition if more modes are added to it
        if (PlayerPrefsManager.activityPrefs < ActivityManager.instance.activitiesParent.transform.childCount - 1)
        {
            if (PlayerPrefsManager.activityPrefs == PlayerPrefsManager.unlockedActivityPrefs)
            {
                PlayerPrefsManager.unlockedActivityPrefs++;
            }
            PlayerPrefsManager.activityPrefs++;
        }
        else
        {
            PlayerPrefsManager.activityPrefs = Random.Range(0, ActivityManager.instance.activitiesParent.transform.childCount);
        }

        LoadScene("GamePlay");
        
    }
    public GameObject skipPanel;
    public void ShowSkipPanel()
    {
        skipPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void HideSkipPanel()
    {
        Time.timeScale = 1;
        skipPanel.SetActive(false);
    }

    public void SkipLevel()
    {

        NextLevel();

    }

    public void ActivityCompleted()
    {
        ShowWinPanel();
    }
    public GameObject winPanel;
    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    public GameObject pausePanel;
    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Restart()
    {
        LoadScene("GamePlay");
    }


    public void Home()
    {
        LoadScene("MainMenu");
    }

    public void Next()
    {
        NextLevel();
    }
    public GameObject player;
    public void SetPlayerPositionAndRotation(Transform tf)
    {
        player.transform.SetPositionAndRotation(tf.position, tf.rotation);
            
    }
    public GameObject fade;
    public void FadeInOut()
    {
        StartCoroutine("FadeOnOff");
    }

    IEnumerator FadeOnOff()
    {
        fade.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        fade.SetActive(false);
    }

    public void Run(bool isRunning)
    {
        player.GetComponent<FirstPersonController>().m_IsWalking = !isRunning;
    }


    [SerializeField] GameObject playerControls;

    public void ToggleControls(bool toggle)
    {
        playerControls.SetActive(toggle);
    }


    public void HandCarryAnim(bool carry)
    {
        if (carry)
        {
            player.GetComponent<Animator>().SetLayerWeight(1, 1);
        }
        else
        {
            player.GetComponent<Animator>().SetLayerWeight(1, 0);
        }
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

    public TextMeshProUGUI fadeText;

    public void SetFadeText(string text)
    {
        fadeText.text = text;
    }

    public HUDNavigationSystem hudSystem;
    public Transform car;
    public Camera carCamera, playerCamera;
    public void CarOn(bool toggle)
    {
        if (toggle)
        {
            hudSystem.PlayerCamera = carCamera;
            hudSystem.PlayerController = car;
        }
        else
        {
            hudSystem.PlayerController = player.transform;
            hudSystem.PlayerCamera = playerCamera;
        }
    }

}
