﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnemyHealthSystem : MonoBehaviour {

    public float health = 0;
    private float damage = 0;
    //TODO: Add public float damage to use in other scripts for damage
    private Scr_AudioManager audioManager;

    void Start()
    {
        audioManager = Scr_AudioManager.instance;
    }


	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            damage = 5f;
            other.gameObject.SetActive(false);
            TakeDamage(damage);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Enemy hit - play sound");
            audioManager.PlaySound("HitEnemy");
            Debug.Log("Sound should've been played");
        }

        if (other.gameObject.CompareTag("CormorantBird"))
        {
            damage = 2.5f;
            TakeDamage(damage);
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
