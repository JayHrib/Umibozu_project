using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CormorantAI : MonoBehaviour {

    //Movement
    public float movementSpeed;
    public float turningSpeed;
    public Transform[] patrolSpots;
    private GameObject ship;
    private bool hasBeenReached = false;

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
        ship = GameObject.FindGameObjectWithTag("Player");
	}

	void FixedUpdate () {
        for (int i = 0; i < targets.Length; i++)
        {
            if (!targets[i].gameObject.activeInHierarchy)
            {
                continue;
            }

            else if (targets[i].gameObject.activeInHierarchy && ReturnDistance(targets[i]) < attackRange)
            {
                AttackTarget(targets[i]);
                return;
            }

            else
            {
                //AttackTarget(ship);
                //PatrolShip();
            }
        }
    }

    void CheckDistance()
    {
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].gameObject.activeInHierarchy && ReturnDistance(targets[i]) < attackRange)
            {
                AttackTarget(targets[i]);
                continue;
            }
            else
            {
                AttackTarget(ship);
                //PatrolShip();
            }
        }
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
        for (int i = 0; i < patrolSpots.Length; i++)
        {
            while (!hasBeenReached)
            {
                if (ReturnDistance(patrolSpots[i].gameObject) > 0.2f)
                {
                    LookAtTarget(patrolSpots[i].gameObject);
                    transform.position = Vector2.MoveTowards(transform.position, patrolSpots[i].position, movementSpeed * Time.deltaTime);
                }
                else
                {
                    hasBeenReached = true;
                    break;
                }
            }

            if (i > patrolSpots.Length)
            {
                i = 0;
            }
            hasBeenReached = false;
        }
    }
}
