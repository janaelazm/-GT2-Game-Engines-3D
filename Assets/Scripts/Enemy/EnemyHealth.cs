using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour

{
    public int maxHealth;
    public int currentHealth;
    private GameObject playerWeapon;
    public SwordHitbox sword;
    private int damage;
    private SoundEffectsManager _soundEffectsManager;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _soundEffectsManager = FindObjectOfType<SoundEffectsManager>();
        currentHealth = maxHealth;
        playerWeapon = GameObject.FindGameObjectWithTag("Weapon");
        damage = sword.swordDamage;
        //healthBar.SetMaxHealth(maxHealth);

    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject == playerWeapon)
        {
            _soundEffectsManager.playSoundEffect(3);
            TakeDamage(damage);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            _animator.SetBool("isDead", true);
            _soundEffectsManager.playSoundEffect(0);
        }
        //healthBar.SetHealth(currentHealth);
    }
}
