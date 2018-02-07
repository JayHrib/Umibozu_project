using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Spotlight : MonoBehaviour {

    public float rotSpeed;
    public Transform spotlightLight;
    private Quaternion rot;

    private void Start()
    {
        rot = transform.rotation;
    }
    void Awake()
    {
        spotlightLight = transform.Find("Obj_Spotlight");
    }

	// Update is called once per frame
	void Update () {
        
        float z = rot.eulerAngles.z;
       
        if (spotlightLight.gameObject.activeInHierarchy)
        {
            z -= rotSpeed * Time.deltaTime;
            rot = Quaternion.Euler(0, 0, z);
            transform.rotation = rot;
        } 
	}
}
