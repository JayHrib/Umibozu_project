using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_EndScreen : MonoBehaviour {

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
