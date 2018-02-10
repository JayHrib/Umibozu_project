using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ProjectileHandler : MonoBehaviour {

    private float destroyTimer = 5f;
    private float timeToDestroy = 0f;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 10);
            //(GetComponent<Collision2D>(), GameObject.FindWithTag("Player").GetComponent<Collision2D>());
    }

    void Update()
    {
        if (destroyTimer > timeToDestroy)
        {
            destroyTimer -= Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}
