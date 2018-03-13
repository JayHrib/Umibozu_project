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

    public void NextPage()
    {
        SceneManager.LoadScene(3);
    }

    public void PrevPage()
    {
        SceneManager.LoadScene(2);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void DebugShowEndScene()
    {
        SceneManager.LoadScene(5);
    }
}
