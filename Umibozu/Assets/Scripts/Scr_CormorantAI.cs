using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CormorantAI : MonoBehaviour {

    //Movement
    public float movementSpeed;
    public float turningSpeed;
    public Transform[] patrolSpots;
    private int patrolSpotIndex = 0;
   
    private Queue<GameObject> targetQueue;
    public enum Modes {Patrol, Attack}
    private Modes mode;
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
        mode = Modes.Patrol;
        targetQueue = new Queue<GameObject>();
    }

    void FixedUpdate()
    {
        switch(mode)
        {
            case Modes.Attack:
                if(targetQueue.Count > 0)
                {
                    AttackTarget(targetQueue.Peek());// targets the first target.

                }
                break;
            case Modes.Patrol:
                PatrolShip();
                break;
            default:
                PatrolShip();
                break;
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

    public void AttackTarget(GameObject target)
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

    public void SetMode(Modes newMode)
    {
        this.mode = newMode;
        Debug.Log("Setting Cormorant Mode to: " + newMode.ToString());
    }

    public void AddTargetToQueue(GameObject enemyTarget)
    {
        this.targetQueue.Enqueue(enemyTarget);
        //Debug.Log("Adding a target: " + enemyTarget.name);
    }

    public void RemoveTargetFromQueue(GameObject enemyTarget)//need to improve, as right now the list just removes the first target from the list. 
    {
        if(targetQueue.Count >0 && this.targetQueue.Peek().Equals(enemyTarget)) //A custom list should be created that can take care of this issue.
        {
            targetQueue.Dequeue(); 
        }
    }
}
