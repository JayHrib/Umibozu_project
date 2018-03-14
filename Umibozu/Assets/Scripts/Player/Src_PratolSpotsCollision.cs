using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Src_PratolSpotsCollision : MonoBehaviour {
    public Transform cormorant;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (cormorant.gameObject.activeInHierarchy && (collision.gameObject.tag == "Shark" || collision.gameObject.tag == "Squid"))
        {
            Debug.Log("Enemy entered the PatrolArea");
            cormorant.gameObject.GetComponent<Scr_CormorantAI>().AddTargetToQueue(collision.gameObject);
            cormorant.gameObject.GetComponent<Scr_CormorantAI>().SetMode(Scr_CormorantAI.Modes.Attack);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (cormorant.gameObject.activeInHierarchy && (collision.gameObject.tag == "Shark" || collision.gameObject.tag == "Squid"))
        {
            Debug.Log("Enemy has exit the PatrolArea");
            cormorant.gameObject.GetComponent<Scr_CormorantAI>().RemoveTargetFromQueue(collision.gameObject);
            cormorant.gameObject.GetComponent<Scr_CormorantAI>().SetMode(Scr_CormorantAI.Modes.Patrol);
        }
    }
}
