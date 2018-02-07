using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ProjectileSystem : MonoBehaviour {

    public GameObject projectilePrefab;
    public Camera cam;
    public float fireRate;

    private float nextFire;
    private List<GameObject> Projectiles = new List<GameObject>();

    private float projectileVelocity;


	// Use this for initialization
	void Start () {
        projectileVelocity = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1") /*&& Time.time > nextFire*/)
        {
            //nextFire = Time.time + nextFire;
            GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            Projectiles.Add(bullet);
        }

        for (int i = 0; i < Projectiles.Count; i++)
        {
            GameObject goBullet = Projectiles[i];
            if (goBullet != null)
            {               
                goBullet.transform.Translate(Input.mousePosition * Time.deltaTime * projectileVelocity);

                Vector3 bulletScreenPos = cam.WorldToScreenPoint(goBullet.transform.position);
                if (bulletScreenPos.y >= Screen.height || bulletScreenPos.y <= 0
                    || bulletScreenPos.x >= Screen.width || bulletScreenPos.x <= 0)
                {
                    DestroyObject(goBullet);
                    Projectiles.Remove(goBullet);
                }
            }
        }

    }

}

