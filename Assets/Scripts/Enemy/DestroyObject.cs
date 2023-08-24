using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
   //attached after last frame of enemy death animation to destroy object
   public void Destroyobj()
   {
      Destroy(gameObject);
   }
}
