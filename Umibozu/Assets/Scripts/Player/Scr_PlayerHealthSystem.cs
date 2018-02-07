using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr_PlayerHealthSystem : MonoBehaviour {

    public Image healthBar;
    public float maxHealth;
    public Color damageColor;
    private float currentHealth = 0f;
    private float damage = 0f;
    private float healthRegen = 15.0f;
    private Color originalColor;
    private float timerDamageColorChange = 0;
    float shake = 0;
    float shakeAmount = 0.7f;
    float decreaseFactor = 1;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        originalColor = this.GetComponent<SpriteRenderer>().color;
	}

    // Update is called once per frame
    void Update()
    {

        if (this.GetComponent<SpriteRenderer>().color != originalColor)
        {
            Debug.Log("Color is not original");
            timerDamageColorChange++;
            DamageEffect(timerDamageColorChange);
            GameObject.FindGameObjectWithTag("MainCamera").transform.localPosition = Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;
        }

    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            damage = 15f;
            TakeDamage(damage);
        }

        if (other.gameObject.CompareTag("Shark"))
        {
            damage = 20f;
            TakeDamage(damage);
        }

        if (other.gameObject.CompareTag("HealthPack") && currentHealth != maxHealth)
        {
            other.gameObject.SetActive(false);
            RegenHealth(healthRegen);
        }
    }

    void TakeDamage(float damage)
    {
        Debug.Log("Taking damage!");
        this.GetComponent<SpriteRenderer>().color = damageColor;
        currentHealth -= damage;
        float calcHealth = currentHealth / maxHealth; //Calculate % of maxHealth for UI
        SetHealth(calcHealth);

        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            //TODO: Play death animation
            TriggerLoss();
        }
    }

    void RegenHealth(float regenAmount)
    {
        currentHealth += regenAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        float calcHealth = currentHealth / maxHealth; //Calculate % of maxHealth for UI
        SetHealth(calcHealth);
    }

    private void DamageEffect(float timer)
    {

        if (timer > ((1 / Time.deltaTime) / 2))
        {
            this.GetComponent<SpriteRenderer>().color = originalColor;
            timerDamageColorChange = 0;
            shake = 0;
        }
    }

    void SetHealth(float myHealth)
    {
        healthBar.fillAmount = myHealth;
    }

    void TriggerLoss()
    {
        FindObjectOfType<Scr_GameManager>().EndGame();
    }
}
