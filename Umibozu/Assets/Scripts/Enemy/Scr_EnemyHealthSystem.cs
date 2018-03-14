using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnemyHealthSystem : MonoBehaviour {

    //In game
    public float health = 0;
    private float damage = 0;
    //TODO: Add public float damage to use in other scripts for damage
    private Scr_AudioManager audioManager;
    private GameObject childInkSplatterObj;

    void Start()
    {
        audioManager = Scr_AudioManager.instance;
        childInkSplatterObj = transform.GetChild(1).gameObject;
    }


	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            damage = 5f;
            other.gameObject.SetActive(false);
            TakeDamage(damage);
            if (childInkSplatterObj.gameObject.activeInHierarchy)
            {
                childInkSplatterObj.gameObject.SetActive(false);
            }
            childInkSplatterObj.transform.position = other.gameObject.transform.position;
            childInkSplatterObj.transform.rotation = other.gameObject.transform.rotation;
            childInkSplatterObj.gameObject.SetActive(true);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            audioManager.PlaySound("HitEnemy");
        }

        if (other.gameObject.CompareTag("CormorantBird"))
        {
            audioManager.PlaySound("HitEnemy");
            damage = 2.5f;
            TakeDamage(damage);
            Debug.Log("in Enemy Trigger Enter");
        }
    }

    void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameObject tmp = GameObject.FindGameObjectWithTag("InkSpill");
            if (tmp.activeSelf)
            {
                tmp.SetActive(false);
            }

            tmp.transform.position = this.transform.position;
            tmp.SetActive(true);

            this.gameObject.SetActive(false);
        }
    }
}
