using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnemyHealthSystem : MonoBehaviour {

    public float health = 0;
    private float damage = 0;
    //TODO: Add public float damage to use in other scripts for damage

	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            damage = 5;
            other.gameObject.SetActive(false);
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
