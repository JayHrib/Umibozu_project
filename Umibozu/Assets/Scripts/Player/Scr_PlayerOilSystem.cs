using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_PlayerOilSystem : MonoBehaviour {

    public Image oilMeter;
    public float maxOil;
    public float spotlightOilDrain;
    public float lanternOilDrain;
    private float currentOil;
    private float oilRefill;
    public Transform spotLight;

	// Use this for initialization
	void Start () {
        currentOil = maxOil;
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
        currentOil = Mathf.Clamp(currentOil, 0, maxOil);
        float calcOil = currentOil / maxOil; //Calculate % of maxOil for UI

        if (currentOil <= 0)
        {
            spotLight.gameObject.SetActive(false);
            //Use IEnum to deactivate lantern after a a small period of time
            TriggerLoss();
        }
        SetOil(calcOil);
    }

    void RefillOil(float oilRefill)
    {
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

    void TriggerLoss()
    {
        FindObjectOfType<Scr_GameManager>().EndGame();
    }
}
