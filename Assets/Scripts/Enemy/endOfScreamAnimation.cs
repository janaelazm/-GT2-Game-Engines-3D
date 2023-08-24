using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endOfScreamAnimation : MonoBehaviour
{
    //called in screamState script to make monster run after scream
   public bool animationFinished = false;
   
   public void animationIsDone()
    {
        animationFinished = true;
    }
}
