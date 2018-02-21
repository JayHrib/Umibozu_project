using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_EnemyAI : MonoBehaviour {

    private Rigidbody2D rb;

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
    private bool hitPlayer = false;
    private IEnumerator coroutine;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
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
            MoveAway();
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
        //transform.localPosition = Vector2.MoveTowards(transform.localPosition, moveSpot.localPosition, enemyMovementSpeed * Time.deltaTime);
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
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, target.position, -enemyMovementSpeed * Time.deltaTime);
        coroutine = MoveBackTimer(2.0f);
    }

    private IEnumerator MoveBackTimer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            hitPlayer = false;
        }
    }

}
