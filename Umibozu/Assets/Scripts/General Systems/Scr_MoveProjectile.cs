using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MoveProjectile : MonoBehaviour {

    private float destroyTimer = 5f;
    private float timeToDestroy = 0f;

    private void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), GameObject.FindWithTag("Player").GetComponent<Collider2D>());
    }

    void Update()
    {
        if (destroyTimer > timeToDestroy)
        {
            destroyTimer -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    

}
