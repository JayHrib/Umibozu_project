using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Changescene : MonoBehaviour {

    public int sceneToEnter;
    public float changeTimer = 4f;
	
	// Update is called once per frame
	void Update () {
		if (changeTimer <= 0)
        {
            SceneManager.LoadScene(sceneToEnter);
        }
        else
        {
            changeTimer -= Time.deltaTime;
        }

        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneToEnter);
        }
	}
}
