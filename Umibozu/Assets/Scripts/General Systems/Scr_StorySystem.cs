using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Images
{
    public Sprite frame;
}

public class Scr_StorySystem : MonoBehaviour {

    public static Scr_StorySystem instance;

    public float timer = 7f;
    
    private float timeToChangeFrame;
    private int currentFrame;
    private Image imageToShow;


    [SerializeField]
    Images[] frames;

	// Use this for initialization
	void Start () {
		if (frames[0] == null && frames[1] == null)
        {
            Debug.LogWarning("StorySystem: frames array is empty!");
        }

        imageToShow = GetComponent<Image>();
        currentFrame = 0;
        timeToChangeFrame = timer;
	}
	
	// Update is called once per frame
	void Update () {
		
        if (timeToChangeFrame > 0)
        {
            timeToChangeFrame -= Time.deltaTime;
        }
        else if (timeToChangeFrame <= 0 && currentFrame < frames.Length)
        {
            ChangeImage(currentFrame);
            currentFrame++;
            timeToChangeFrame = timer;
        }

        else if (timeToChangeFrame <= 0 && currentFrame >= frames.Length)
        {
            Debug.Log("Out of frames!");
        }

    }

    void ChangeImage(int index)
    {
        imageToShow.sprite = ReturnImage(index);
    }

    public void NextImage()
    {
        //Used for onclick event
        currentFrame++;
        if (currentFrame == frames.Length)
        {
            currentFrame = (frames.Length - 1);
        }

        ChangeImage(currentFrame);
        timeToChangeFrame = timer;
    }

    public void PreviousImage()
    {
        //Used for onclick event
        currentFrame--;
        if (currentFrame <= 0)
        {
            currentFrame = 0;
        }

        ChangeImage(currentFrame);
        timeToChangeFrame = timer;
    }

    Sprite ReturnImage(int index)
    {

        Sprite toReturn = null;

        for (int i = 0; i < frames.Length; i++)
        {
            if (i == index)
            {
                toReturn = frames[i].frame;
                break;
            }
        }

        return toReturn;
    }
}
