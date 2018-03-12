using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_RotateHarpoonGun : MonoBehaviour {
    private Transform parentTransform;

    private void Start()
    {
        parentTransform = transform.GetComponentInParent<Transform>();
    }
    // Update is called once per frame
    void Update () {
        //transform.rotation = parentTransform.rotation;

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        if (!Scr_PauseMenu.GameIsPaused)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ - 90);//cahnged to rotate accourding to world's space
        }
	}
}
