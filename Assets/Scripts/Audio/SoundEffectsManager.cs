using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] soundeffects;

    public void playSoundEffect(int i)
    {
        soundeffects[i].Play();
    }
    
    public void stopSoundEffect(int i)
    {
        soundeffects[i].Stop();
    }
    
    public void pauseSoundEffect(int i)
    {
        soundeffects[i].Pause();
    }

    public void setLoopSoundEffect(int i, bool b)
    {
        soundeffects[i].loop = b;
    }

}
