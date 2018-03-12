using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_SpotlightActive : MonoBehaviour {

    public Transform spotlight;
	
	// Update is called once per frame
	void Update () {
		if (!Scr_PauseMenu.GameIsPaused)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                FindObjectOfType<Scr_AudioManager>().PlaySound("LightSwitch");
                OnOff();
            }
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
