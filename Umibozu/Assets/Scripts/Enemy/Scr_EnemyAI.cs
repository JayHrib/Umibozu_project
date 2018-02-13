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
    private bool hitPlayer = false;
    private IEnumerator coroutine;

    void Start () {
        waitTime = startWaitTime;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        targetDistance = Vector3.Distance(target.position, transform.position);
        LookAtTarget(target);

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

    void LookAtTarget(Transform targetPos)
    {
        Vector2 direction = Camera.main.WorldToViewportPoint(targetPos.position) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }

    void PatrolArea()
    {
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, moveSpot.localPosition, enemyMovementSpeed * Time.deltaTime);

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
        transform.position = Vector2.MoveTowards(transform.localPosition, target.position, -enemyMovementSpeed * Time.deltaTime);
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
