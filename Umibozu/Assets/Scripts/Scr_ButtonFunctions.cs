using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_ButtonFunctions : MonoBehaviour {

    private Scr_StorySystem _storyManager;

    void Start()
    {
        _storyManager = Scr_StorySystem.instance;

        if (_storyManager == null)
        {
            Debug.Log("Sum Wong");
        }
    }

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

    public void NextImage()
    {
        _storyManager.NextImage();
    }

    public void PrevImage()
    {
        _storyManager.PreviousImage();
    }
}
