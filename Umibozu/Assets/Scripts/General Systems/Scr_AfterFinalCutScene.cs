using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Scr_AfterFinalCutScene : MonoBehaviour {

    VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPrepared && !videoPlayer.isPlaying)
        {
            SceneManager.LoadScene(4);
        }
    }
}


