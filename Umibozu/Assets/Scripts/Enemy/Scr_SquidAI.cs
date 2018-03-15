using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_SquidAI : MonoBehaviour {

    private Rigidbody2D rb;

    private float targetDistance;
    public float enemyLookDistance;
    public float attackDistance = 10f;
    public float enemyMovementSpeed = 1.5f;
    public float rotationSpeed;
    public Transform target;

    public Transform moveSpot;
    private bool hitPlayer = false;
    public float moveBackTimer = 3f;
    private float timeToAttack;
    public float moveTimer = 2f;
    private float timeToMove;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        timeToAttack = moveBackTimer;
        timeToMove = moveTimer;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        targetDistance = Vector3.Distance(target.position, transform.position);
        LookAtTarget(moveSpot);

        //Chase player
        if (targetDistance < attackDistance && !hitPlayer)
        {
            LookAtTarget(target);
            transform.position = Vector2.MoveTowards(transform.position, target.position, (enemyMovementSpeed / 2) * Time.deltaTime);
        }

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
        if (timeToMove <= 0)
        {
            rb.velocity = transform.up * enemyMovementSpeed;
            timeToMove = moveTimer;
        }
        else
        {
            timeToMove -= Time.deltaTime;
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
            rb.velocity = transform.up * -enemyMovementSpeed;
            //transform.position = Vector2.MoveTowards(transform.position, target.position, (-enemyMovementSpeed - 8.5f) * Time.deltaTime);
            timeToAttack -= Time.deltaTime;
        }
    }
}
