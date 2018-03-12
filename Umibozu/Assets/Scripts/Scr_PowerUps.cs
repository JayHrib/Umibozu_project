using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PowerUps : MonoBehaviour {

    public Transform cormorant;
    public float cormorantTimer;
    private float countDown;

	// Use this for initialization
	void Start () {
        countDown = cormorantTimer;
	}
	
	// Update is called once per frame
	void Update () {
		if (cormorant.gameObject.activeInHierarchy)
        {
            if (countDown > 0)
            {
                countDown -= Time.deltaTime;
            }
            else
            {
                cormorant.gameObject.SetActive(false);
                countDown = cormorantTimer;
            }
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CormorantPickUp") && !cormorant.gameObject.activeInHierarchy)
        {
            cormorant.gameObject.SetActive(true);
            other.gameObject.SetActive(false);
        }
    }
}
