using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    [SerializeField] private GameObjectSet enemySet;
    private GameObject enemy;
    private EnemyHealth enemyHealthComponent;

    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI healthText;

    private float health;
    private float maxHealth;
    private float lerpSpeed;

    private void Start()
    {
       
    }

    private void Update()
    {
        if(enemySet.Items.Count > 0)
        {
            foreach (var item in enemySet.Items)
            {
                if (item.CompareTag("BossEnemy"))
                {
                    enemyHealthComponent = item.GetComponent<EnemyHealth>();
                    healthText.gameObject.SetActive(true);
                    healthBar.gameObject.SetActive(true);
                }
            }

            if (enemyHealthComponent != null)
            {
                maxHealth = enemyHealthComponent.hp;

                healthText.text = "Bosshealth: " + enemyHealthComponent.hp;

                if (enemyHealthComponent.hp > maxHealth)
                {
                    enemyHealthComponent.hp = maxHealth;
                }

                lerpSpeed = 3f * Time.deltaTime;

                HealthBarFiller();
            }
            else
            {
                // Fehlerbehandlung, falls das Skript nicht gefunden wurde
                //Debug.LogError("EnemyHealth-Skript nicht gefunden!");
            }
        }        
    }

    private void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, enemyHealthComponent.hp / maxHealth, lerpSpeed);
    }
}
