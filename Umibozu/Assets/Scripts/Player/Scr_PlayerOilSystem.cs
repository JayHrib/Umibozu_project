using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_PlayerOilSystem : MonoBehaviour {

    private Scr_AudioManager audioManager;

    public Image oilMeter;
    public float maxOil;
    public float spotlightOilDrain;
    public float lanternOilDrain;
    private float currentOil;
    private float oilRefill;
    public Transform spotLight;
    public Transform lantern;

    public float minSec = 0.5f;
    public float maxSec = 1.5f;

    private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
        currentOil = maxOil;
        audioManager = Scr_AudioManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
        //Only drain oil if spotlight is active
        if (spotLight.gameObject.activeInHierarchy)
        {
            DrainOil(spotlightOilDrain);
        }

        DrainOil(lanternOilDrain);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("OilBarrel") && currentOil != maxOil)
        {
            oilRefill = 20.0f;
            RefillOil(oilRefill);
            other.gameObject.SetActive(false);
        }
    }

    void DrainOil(float drain)
    {
        currentOil -= drain * Time.deltaTime;
        float calcOil = currentOil / maxOil; //Calculate % of maxOil for UI

        if (currentOil <= 0)
        {
            spotLight.gameObject.SetActive(false);
            //Use IEnum to deactivate lantern after a a small period of time
            coroutine = ShutDownLight();
        }
        SetOil(calcOil);
    }

    void RefillOil(float oilRefill)
    {
        audioManager.PlaySound("OilPickUp");

        currentOil += oilRefill;

        if (currentOil > maxOil)
        {
            currentOil = maxOil;
        }

        float calcOil = currentOil / maxOil; //Calculate % of maxOil for UI
        SetOil(calcOil);
    }

    void SetOil(float myOil)
    {
        oilMeter.fillAmount = myOil;
    }

    IEnumerator ShutDownLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSec, maxSec));
            if (lantern.gameObject.activeInHierarchy)
            {
                lantern.gameObject.SetActive(false);
            }
            else
            {
                lantern.gameObject.SetActive(true);
            }
        }
    }
}
