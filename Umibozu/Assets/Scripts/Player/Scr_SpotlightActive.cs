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
                OnOff();
            }
        }
	}

    void OnOff()
    {
        if (spotlight.gameObject.activeInHierarchy)
        {
            FindObjectOfType<Scr_AudioManager>().PlaySound("SnuffLantern");
            spotlight.gameObject.SetActive(false);
        }
        else
        {
            FindObjectOfType<Scr_AudioManager>().PlaySound("LightLantern");
            spotlight.gameObject.SetActive(true);
        }
    }
}
