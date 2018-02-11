using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject screenGUI;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        screenGUI.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        screenGUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        Resume();
        FindObjectOfType<Scr_GameManager>().Restart();
    }

}
