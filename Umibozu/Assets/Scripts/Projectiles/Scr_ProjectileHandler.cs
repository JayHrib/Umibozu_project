using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_ProjectileHandler : MonoBehaviour {

    public float destroyTimer = 2f;

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(8, 10);
    }

    void OnEnable()
    {
        Invoke("Destroy", destroyTimer);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnBecameInvisible()
    {
        Destroy();
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
