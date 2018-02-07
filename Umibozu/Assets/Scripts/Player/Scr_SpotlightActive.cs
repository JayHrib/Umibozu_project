using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_SpotlightActive : MonoBehaviour {

    public Transform spotlight;
	
	// Update is called once per frame
	void Update () {
		
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnOff();
        }
	}

    void OnOff()
    {
        if (spotlight.gameObject.activeInHierarchy)
        {
            spotlight.gameObject.SetActive(false);
        }
        else
        {
            spotlight.gameObject.SetActive(true);
        }
    }
}
