using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_SquidAI : MonoBehaviour {

    private Rigidbody2D rb;

    private float targetDistance;
    public float enemyLookDistance;
    public float attackDistance;
    public float enemyMovementSpeed;
    public float rotationSpeed;
    public Transform target;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    private bool hitPlayer = false;
    private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
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
        rb.velocity = transform.up * enemyMovementSpeed;

        if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            LookAtTarget(moveSpot);
            moveSpot.localPosition = new Vector2(Random.Range(-35, 35), Random.Range(-25, 100));
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
