using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_cameraBehavior : MonoBehaviour {

    bool lockPlayerPos = false;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {

        if(player.transform.position.y >= 0)
        {
            lockPlayerPos = true;
        }
        
        if(lockPlayerPos)
        {
            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);     
        }


    }
}
