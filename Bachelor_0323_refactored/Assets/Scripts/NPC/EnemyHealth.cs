using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public FloatReference health;

    [HideInInspector] public float hp;
    private float prevHP;

    [SerializeField] private AudioData goblinHitSounds;
    [SerializeField] private AudioData goatHitSounds;

    public AudioSource goblinSource;
    public AudioSource goatSource;

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
        }

        if (hp <= 0)
        {
            hp = 0;
            gameObject.SetActive(false);
        }
    }
}
