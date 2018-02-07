using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerMovement : MonoBehaviour {

    public float movementSpeed;
    public float rotationSpeed;

	// Update is called once per frame
	void Update () {

        //Rotate boat
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //Move boat
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime, 0);

        pos += rot * velocity;
        transform.position = pos;
    }
}
