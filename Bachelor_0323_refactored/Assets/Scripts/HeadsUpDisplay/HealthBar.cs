using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    private PlayerHealth playerHealthComponent;

    private float maxHealth;
    private float lerpSpeed;


    private void Start()
    {
        playerHealthComponent = player.transform.GetChild(0).gameObject.GetComponent<PlayerHealth>();

        if (playerHealthComponent != null)
        {
            maxHealth = playerHealthComponent.hp;
        }
        else
        {
            // Fehlerbehandlung, falls das Skript nicht gefunden wurde
            Debug.LogError("PlayerHealth-Skript nicht gefunden!");
        }
    }

    private void Update()
    {
        healthText.text = "Health: " + playerHealthComponent.hp;

        if(playerHealthComponent.hp > maxHealth)
        {
            playerHealthComponent.hp = maxHealth;
        }

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        HealthColorChanger();
    }

    private void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, playerHealthComponent.hp / maxHealth, lerpSpeed);
    }

    private void HealthColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (playerHealthComponent.hp / maxHealth));

        healthBar.color = healthColor;
    }
}
