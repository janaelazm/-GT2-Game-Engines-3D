using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    
    private ScreenHandler _screenHandler;

    private void Start()
    {
        _screenHandler = FindObjectOfType<ScreenHandler>();
    }

    public void winGame()
    {
        _screenHandler.PlayerWin();
    }
}
