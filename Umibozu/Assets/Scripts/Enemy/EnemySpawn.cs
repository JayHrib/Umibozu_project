using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject enemyPrefab;
    //float randX;
    Vector2 spawnpoint;
    public float spawnRate = 2f;
    private float nextSpawn = 0.0f;
    public float spawnRangeFromPlayerMinX = 10f;
    public float spawnRangeFromPlayerMaxX = 15f;
    public float spawnRangeFromPlayerMinY = 10f;
    public float spawnRangeFromPlayerMaxY = 15f;
    public int maxAmountEnemies = 15;
    private int amountOfEnemies = 0;
    


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            //randX = Random.Range(-1 * randomRange, randomRange);
            if(GameObject.FindGameObjectsWithTag("Shark") != null)
            {
                amountOfEnemies = GameObject.FindGameObjectsWithTag("Shark").Length;               
            }
             

            if ( amountOfEnemies < maxAmountEnemies)
            {
                Debug.Log("amount of enemies = " + amountOfEnemies);

                spawnpoint = GetRandomPositionOutsideCamera();
                Instantiate(enemyPrefab, spawnpoint, Quaternion.identity);
            }
            
        }
	}

    private Vector2 GetRandomPositionOutsideCamera()
    {
        /*float screenAspect = (float)Screen.width / (float)Screen.height;
        float camHalfHeight = Camera.main.orthographicSize;
        float camHalfWidth = screenAspect * camHalfHeight;
        float camWidth = 2.0f * camHalfWidth;
        float camHeight = 2.0f * camHalfHeight;*/

        Random.seed = Random.RandomRange(1, 200);

        int positiveOrNegative = Random.Range(1,2);
        float spawnAreaX = GameObject.FindGameObjectWithTag("MainCamera").transform.position.x;
        float spawnAreaY = GameObject.FindGameObjectWithTag("MainCamera").transform.position.y - 10;

        if (positiveOrNegative == 2)
        {
            spawnAreaX += Random.Range(spawnRangeFromPlayerMinX, spawnRangeFromPlayerMaxX);

        }
        else
        {
            spawnAreaX -= Random.Range(spawnRangeFromPlayerMinX, spawnRangeFromPlayerMaxX);
        }
            

        return new Vector2(spawnAreaX, spawnAreaY); 
    }


}
