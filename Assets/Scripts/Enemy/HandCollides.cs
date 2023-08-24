using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCollides : MonoBehaviour
{
    //to play hit sound on certain frame when monster is attacking
    private SoundEffectsManager _soundEffectsManager;

    private void Start()
    {
        _soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
    }

    public void playHitSound()
    {
        _soundEffectsManager.playSoundEffect(5);
    }
}
