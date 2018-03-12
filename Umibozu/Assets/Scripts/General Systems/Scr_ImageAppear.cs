using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_ImageAppear : MonoBehaviour {

    [SerializeField] private Image customImage;
    private bool toContinue = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            customImage.enabled = true;
        }
    }

    void Update()
    {
        if (Input.anyKeyDown && customImage.enabled)
        {
            customImage.enabled = false;
            toContinue = true;
        }

        if (toContinue)
        {
            Destroy(this.gameObject);
        }
    }
}
