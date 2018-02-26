using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CormorantAI : MonoBehaviour {

    //Movement
    public float movementSpeed;
    public float turningSpeed;
    public Transform[] patrolSpots;
    private int patrolSpotIndex = 0;

    //Targeting
    public float attackRange = 5;
    private float targetDistance;

    private Rigidbody2D rb;
    private GameObject[] targets;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        targets = GameObject.FindGameObjectsWithTag("Shark");
        targets = GameObject.FindGameObjectsWithTag("Squid");
	}

    void FixedUpdate()
    {
        PatrolShip();
    }

    float ReturnDistance(GameObject target)
    {
        targetDistance = Vector3.Distance(target.gameObject.transform.position, gameObject.transform.position);
        return targetDistance;
    }

    void LookAtTarget(GameObject target)
    {
        Vector2 direction = (Vector2)target.gameObject.transform.position - rb.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * turningSpeed;
    }

    void AttackTarget(GameObject target)
    {
        LookAtTarget(target);
        transform.position = Vector2.MoveTowards(transform.position, target.gameObject.transform.position, movementSpeed * Time.deltaTime);
    }

    void PatrolShip()
    {
        LookAtTarget(patrolSpots[patrolSpotIndex].gameObject);
        transform.position = Vector2.MoveTowards(transform.position, patrolSpots[patrolSpotIndex].position, (movementSpeed - 2) * Time.deltaTime);

        if (Vector2.Distance(transform.position, patrolSpots[patrolSpotIndex].position) < 0.2f)
        {
            patrolSpotIndex++;

            if (patrolSpotIndex > patrolSpots.Length - 1)
            {
                patrolSpotIndex = 0;
            }
        }
    }
}
