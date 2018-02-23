using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PickUp_Tutorial_Behavior : MonoBehaviour {

    public float movementSpeed;
    public Transform target;
    private bool enableMove;
    private float waitTime;
    public float startWaitTime;
    public GameObject landSide;

    // Use this for initialization
    void Start () {
        enableMove = false;
        waitTime = startWaitTime;
        //Debug.Log("bool move=" + enableMove);
    }
	
	// Update is called once per frame
	void Update () {

        if (!enableMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime);
        }
        else
        {
            //Debug.Log("Enabled moving towards landslide");
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(landSide.transform.position.x, target.position.y), movementSpeed * Time.deltaTime);
        }     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hazard")
        {
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "MovePosition")
        {
            target.position = new Vector2(target.position.x, Random.Range(target.position.y-10, target.position.y + 10));
        }
    }

    

    private void OnBecameVisible()
    {
        //Debug.Log("is visible");
        enableMove = true;
    }



}
