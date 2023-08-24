using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    public enum alphaValue
    {
        shrinking,
        growing
    }
    private TextMeshProUGUI count;
    private int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        count = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        count.text = enemyCount + "/6";
    }

    public int getEnemyCount()
    {
        return enemyCount;
    }
}
