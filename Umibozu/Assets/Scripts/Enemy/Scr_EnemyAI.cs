using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnemyAI : MonoBehaviour {

    //Player detection
    private float targetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float rotationSpeed;
    public Transform target;

    //Patrolling
    private float waitTime;
    public float startWaitTime;
    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    // Use this for initialization
    void Awake()
    {
        if (moveSpot == null)
        {
            Debug.LogError("Error: No move spot found!");
        }
    }

    void Start () {
        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        targetDistance = Vector3.Distance(target.position, transform.position);
        LookAtTarget(target);

        //Turn towards player
        if (targetDistance < enemyLookDistance)
        {
            LookAtTarget(target);
        }

        //Chase player
        if (targetDistance < attackDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, enemyMovementSpeed * Time.deltaTime);
        }

        //Patrol set area
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, enemyMovementSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    LookAtTarget(moveSpot);
                    moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }

        }
	}

    void LookAtTarget(Transform targetPos)
    {
        Vector2 direction = Camera.main.WorldToViewportPoint(targetPos.position) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
