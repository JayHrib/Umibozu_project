using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Final_CutScene : MonoBehaviour
{
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OnTriggerEnter2D");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter2D with player");
            SceneManager.LoadScene(8);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("OnTriggerEnter2D with player");
            SceneManager.LoadScene(8);
        }
    }
}
