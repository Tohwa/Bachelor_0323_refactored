using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public FloatReference health;

    public GameObject lootPrefab;

    [HideInInspector] public float hp;
    private float prevHP;

    [SerializeField] private AudioData goblinHitSounds;
    [SerializeField] private AudioData goatHitSounds;
    [SerializeField] private AudioData bossHitSounds;

    public AudioSource goblinSource;
    public AudioSource goatSource;
    public AudioSource bossSource;

    private float deathTimer;

    private void Start()
    {
        hp = health.Value;
        prevHP = hp;
    }

    private void Update()
    {
        if (prevHP > hp)
        {
            if (gameObject.CompareTag("Goblin"))
            {
                int rndGoblin = Random.Range(0, goblinHitSounds.Clips.Length);
                goblinSource.clip = goblinHitSounds.Clips[rndGoblin];
                goblinSource.Play();
                prevHP = hp;
            }
            else if (gameObject.CompareTag("Goat"))
            {
                int rndGoat = Random.Range(0, goatHitSounds.Clips.Length);
                goatSource.clip = goblinHitSounds.Clips[rndGoat];
                goatSource.Play();
                prevHP = hp;
            }
            else if (gameObject.CompareTag("BossEnemy"))
            {
                int rndGoat = Random.Range(0, bossHitSounds.Clips.Length);
                bossSource.clip = bossHitSounds.Clips[rndGoat];
                bossSource.Play();
                prevHP = hp;
            }
        }

        if (hp <= 0)
        {
            hp = 0;

            if (gameObject.CompareTag("BossEnemy"))
            {
                SceneManager.LoadScene("EndScreen");
                GameManager.bossDead = true;
                gameObject.SetActive(false);
            }
            else
            {
                Instantiate(lootPrefab, gameObject.transform.position, lootPrefab.transform.rotation, null);
                gameObject.SetActive(false);
            }
        }
    }
}
