using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private GameObjectSet enemySet;
    private GameObject enemy;

    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    private float health;
    private float maxHealth;
    private float lerpSpeed;


    private void Start()
    {
        GetBossHealthComponent();
        
        health = maxHealth;
    }

    private void Update()
    {
        GetBossHealthComponent();

        healthText.text = "Health: " + health + "%";

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
    }

    private void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
    }

    private void GetBossHealthComponent()
    {
        foreach (var item in enemySet.Items)
        {
            if (item.CompareTag("BossEnemy"))
            {
                enemy = item;
            }
        }

        EnemyHealth enemyHealthComponent = enemy.GetComponent<EnemyHealth>();

        if (enemyHealthComponent != null)
        {
            maxHealth = enemyHealthComponent.hp;
        }
        else
        {
            // Fehlerbehandlung, falls das Skript nicht gefunden wurde
            Debug.LogError("EnemyHealth-Skript nicht gefunden!");
        }
    }
}
