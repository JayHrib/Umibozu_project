using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnemyAI : MonoBehaviour {

    private Rigidbody2D rb;

    //Player detection
    private float targetDistance;
    public float enemyLookDistance;
    public float attackDistance = 7;
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
    private bool hitPlayer = false;
    public float moveBackTimer = 3f;
    private float timeToAttack;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        timeToAttack = moveBackTimer;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        targetDistance = Vector3.Distance(target.position, transform.position);
        LookAtTarget(moveSpot);

        //Chase player
        if (targetDistance < attackDistance && !hitPlayer)
        {
            LookAtTarget(target);
            transform.position = Vector2.MoveTowards(transform.position, target.position, enemyMovementSpeed * Time.deltaTime);
        }

        //Move back if player has been hit
        else if (hitPlayer)
        {
            MoveAway();
        }

        //Patrol set area
        else
        {
            PatrolArea();
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hitPlayer = true;
        }
    }

    void LookAtTarget(Transform target)
    {
        Vector2 direction = (Vector2)target.position - rb.position;
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotateAmount * rotationSpeed;
    }

    void PatrolArea()
    {
        rb.velocity = transform.up * enemyMovementSpeed;

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                LookAtTarget(moveSpot);
                moveSpot.localPosition = new Vector2(Random.Range(-35, 35), Random.Range(-25, 100));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    void MoveAway()
    {
        if (timeToAttack <= 0)
        {
            hitPlayer = false;
            timeToAttack = moveBackTimer;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -enemyMovementSpeed * Time.deltaTime);
            timeToAttack -= Time.deltaTime;
        }
    }
}
