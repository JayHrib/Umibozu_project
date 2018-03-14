using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Evidence
{
    public Transform pointOfInterest;
}

public class Scr_PinRotator : MonoBehaviour {

    public float rotationSpeed = 120;
    public Transform compassCarrier;
    private Rigidbody2D rb;
    private Rigidbody2D ccrb;

    [SerializeField]
    Evidence[] pointsOfInterest;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        ccrb = compassCarrier.GetComponent<Rigidbody2D>();

        if (ccrb == null)
        {
            Debug.LogWarning("PinRotator: Compass carrier does not have a Rigidbody2D attached to it!");
        }
	}
	
    void FixedUpdate()
    {
        ShowDirection();
    }

    void ShowDirection()
    {
        for (int i = 0; i < pointsOfInterest.Length; i++)
        {
            if (pointsOfInterest[i].pointOfInterest.gameObject.activeInHierarchy)
            {
                Vector2 direction = (Vector2)pointsOfInterest[i].pointOfInterest.position - ccrb.position;
                direction.Normalize();

                float rotateAmount = Vector3.Cross(direction, transform.up).z;

                rb.angularVelocity = -rotateAmount * rotationSpeed;

                return;
            }
        }
    }


}
