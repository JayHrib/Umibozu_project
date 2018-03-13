using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerMovement : MonoBehaviour
{

    public float movementSpeed;
    public float rotationSpeed;
    private Transform harpoonTransform;
    private float previousRotation;
    public bool alternativeControls = false;

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

        harpoonTransform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.z * -1f);
    }

    void FixedUpdate()
    {
        Rigidbody2D rb2d = gameObject.GetComponent<Rigidbody2D>();

        float movePlayer = Input.GetAxis("Vertical");

        //Move boat
        if (alternativeControls && (transform.rotation.eulerAngles.z >= 91 && transform.rotation.eulerAngles.z <= 269)) // if the angle is between 91-269 change the contorls to use 'S' to move forward
        {
            Debug.Log("Reversng controls");
            movePlayer *= -1;
        }

        Vector3 movement = new Vector3(0.0f, movePlayer, 0.0f);
        movement.Normalize();
        rb2d.AddRelativeForce(movement * movementSpeed);
    }

}