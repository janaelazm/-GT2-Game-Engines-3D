using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSpaceship : MonoBehaviour
{
  private GameObject player;
  private GameObject winnerSpaceShip;
  private Animation spaceshipAnimatation;
  private EnemyCounter _enemyCounter;

  private void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player");
    winnerSpaceShip = GameObject.FindGameObjectWithTag("WinnerSpaceShip");
    spaceshipAnimatation = winnerSpaceShip.GetComponent<Animation>();
    spaceshipAnimatation.enabled = false;
    _enemyCounter = GameObject.FindObjectOfType<EnemyCounter>();
  }
  

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject == player && _enemyCounter.getEnemyCount() == 0)
    {
      spaceshipAnimatation.enabled = true;
    }
  }
  
}
