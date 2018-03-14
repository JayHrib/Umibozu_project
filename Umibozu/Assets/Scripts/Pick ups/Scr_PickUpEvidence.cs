using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_PickUpEvidence : MonoBehaviour {

    private Scr_CollectEvidence _evidence;

    void Start()
    {
        GameObject GM = GameObject.Find("_GameMaster");
        _evidence = GM.GetComponent<Scr_CollectEvidence>();

        if (_evidence == null)
        {
            Debug.LogError("Object named Obj_GameManager not present in scene!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Evidence"))
        {
            _evidence.amountPickedUp += 1;
        }
    }
}
