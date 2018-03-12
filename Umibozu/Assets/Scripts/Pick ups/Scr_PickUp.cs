using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PickUp : MonoBehaviour {

    public GameObject pickUpEffect;

    void Awake()
    {
        if (pickUpEffect == null)
        {
            Debug.LogError("No pick up effect found!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PickedUp();
        }
    }

    void PickedUp()
    {
        Instantiate(pickUpEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
