using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] backgroundMusic;

    private void Start()
    {
        playBGM(0);
    }

    public void playBGM(int i)
    {
        backgroundMusic[i].Play();
    }
    
        
    public void stopBGM(int i)
    {
        backgroundMusic[i].Stop();
    }
    
    public void pauseBGM(int i)
    {
        backgroundMusic[i].Pause();
    }

    public void switchBGM(int i)
    {
        foreach (AudioSource audioSource in backgroundMusic)
        {
            audioSource.Stop();
        }
        backgroundMusic[i].Play();
    }
    

}
