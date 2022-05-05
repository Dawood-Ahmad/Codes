using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider loadingBar;

    // Start is called before the first frame update
    void Start()
    {
        LoadScene();
    }

    void LoadScene()
    {
        StartCoroutine(LoadSceneAsync("MainMenu"));
    }

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


}
