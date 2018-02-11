using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    public float delay;

	public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Invoke("LoseScreen", delay);
        }
    }

    public void Restart()
    {
        if (Scr_PauseMenu.GameIsPaused)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void LoseScreen()
    {
        SceneManager.LoadScene(2);
    }
}
