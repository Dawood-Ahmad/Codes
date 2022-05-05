using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundHandler : MonoBehaviour
{
    public AudioClip menuSounds, gameplaySounds;
    [HideInInspector]
    public static SoundHandler instance;
    public Sprite soundOnImg, soundOffImg;
    AudioSource musicPlayer;
    
    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        musicPlayer = GetComponent<AudioSource>();
        PlayMenuMusic();
    }

    public bool IsMusicPlaying()
    {
        if (musicPlayer.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ToggleMusic()
    {
        if (musicPlayer.isPlaying)
        {
            musicPlayer.Stop();
            return false;
        }
        else
        {
            musicPlayer.Play();
            return true;
        }

    }

    public void PlayMenuMusic()
    {
        musicPlayer.clip = menuSounds;
        musicPlayer.Play();
    }

    public void PlayGamePlayMusic()
    {
        musicPlayer.clip = gameplaySounds;
        musicPlayer.Play();
    }

}
