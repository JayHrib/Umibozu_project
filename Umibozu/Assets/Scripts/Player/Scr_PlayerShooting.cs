using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PlayerShooting : MonoBehaviour {

    float fireRate = 0;
    float fireTime = 0;
    public float moveSpeed;
    public float damage = 1;
    public LayerMask whatToHit;
    public float startReloadTimer = 1.0f;
    public float reloadTimer;
    private bool readyToFire = false;

    //cache
    private Scr_AudioManager audioManager;
    private Scr_ObjectPooler objectPool;

    void Start()
    {
        reloadTimer = 0;

        //caching
        audioManager = Scr_AudioManager.instance;
        objectPool = Scr_ObjectPooler.current;

        if (audioManager == null)
        {
            Debug.LogError("Error: No AudioManager found in the scene!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!Scr_PauseMenu.GameIsPaused)
        {
            if (fireRate == 0)
            {
                //Draw bow
                if (Input.GetButtonDown("Fire1") && reloadTimer <= 0)
                {
                    readyToFire = true;
                }

                else if (reloadTimer > 0)
                {
                    reloadTimer -= Time.deltaTime;
                }

                //Release arrow
                if (Input.GetButtonUp("Fire1") && readyToFire)
                {
                    readyToFire = false;
                    Shoot();
                    reloadTimer = startReloadTimer;
                }

            }
            else
            {
                if (Input.GetButton("Fire1") && Time.time > fireTime)
                {
                    fireTime = Time.time + 1 / fireRate;
                    Shoot();
                }
            }
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition).y));

        GameObject arrow = objectPool.GetPooledObject();

        if (arrow == null)
        {
            return;
        }

        arrow.transform.rotation = gameObject.transform.localRotation;
        arrow.transform.position = gameObject.transform.position;
        arrow.SetActive(true);

        arrow.GetComponent<Rigidbody2D>().velocity = new Vector2((mousePosition.x-transform.position.x) * moveSpeed, (mousePosition.y - transform.position.y) * moveSpeed);
        arrow.GetComponent<Rigidbody2D>().velocity.Normalize();
    }
}
