using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PickUp_behavior : MonoBehaviour {

    private void Start()
    {
        Debug.Log("pickup script on");
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile" || collision.gameObject.tag == "")
        {
            Debug.Log("onCollision with projectile");
        }
    }

}
