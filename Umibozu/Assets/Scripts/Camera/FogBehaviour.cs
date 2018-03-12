using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = Camera.main.transform.position;
	}
}
