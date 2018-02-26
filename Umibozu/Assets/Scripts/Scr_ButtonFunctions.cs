using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_ButtonFunctions : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
