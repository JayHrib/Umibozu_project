using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PowerUps : MonoBehaviour {

    public Transform cormorant;
    public float cormorantTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (cormorant.gameObject.activeInHierarchy)
        {
            if (cormorantTimer > 0)
            {
                cormorantTimer -= Time.deltaTime;
            }
            else
            {
                cormorant.gameObject.SetActive(false);
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CormorantPickUp") && !cormorant.gameObject.activeInHierarchy)
        {
            cormorant.gameObject.SetActive(true);
        }
    }
}
