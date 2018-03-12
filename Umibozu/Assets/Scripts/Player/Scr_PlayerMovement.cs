using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerMovement : MonoBehaviour {

    public float movementSpeed;
    public float rotationSpeed;
    private Transform harpoonTransform;
    private float previousRotation;
    private void Start()
    {
        harpoonTransform = transform.GetChild(3);
    }

    void Update()
    {
        previousRotation = transform.rotation.z;

        float rotatePlayer = Input.GetAxis("Horizontal");

        //Rotate boat
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= rotatePlayer * rotationSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        harpoonTransform.rotation = Quaternion.Euler(0f,0f,transform.rotation.z * -1f);
    }

    void FixedUpdate()
    {
        Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();
        float movePlayer = Input.GetAxis("Vertical");

        //Move boat
        Vector3 movement = new Vector3(0.0f, movePlayer, 0.0f);
        movement.Normalize();
        rb2d.AddRelativeForce(movement * movementSpeed);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Evidence")
        {
            Application.LoadLevel("Lose Screen");
        }
    }*/
}
