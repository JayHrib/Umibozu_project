using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    public GameObject enemyPrefab;
    //float randX;
    Vector2 spawnpoint;
    public float spawnRate = 2f;
    private float nextSpawn = 0.0f;
    public float spawnRangeFromPlayer = 5f;
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
            if(GameObject.FindGameObjectsWithTag("Enemy") != null)
            {
                amountOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
                
            }
             

            if ( amountOfEnemies < maxAmountEnemies)
            {
                Debug.Log("amount of enemies = " + amountOfEnemies);
                spawnpoint = new Vector2(Camera.main.transform.position.x + spawnRangeFromPlayer, transform.position.y);
                Instantiate(enemyPrefab, spawnpoint, Quaternion.identity);
            }
            
        }
	}
}
