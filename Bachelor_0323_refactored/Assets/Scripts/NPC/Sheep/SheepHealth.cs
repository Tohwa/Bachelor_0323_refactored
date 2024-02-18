using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHealth : MonoBehaviour
{
    public FloatReference health;

    /*[HideInInspector]*/ public float hp;
    public float prevHP;

    [SerializeField] private AudioData hitSounds;
    [SerializeField] private SheepController controller;

    public AudioSource SFXSource;

    private void Start()
    {
        if (SFXSource == null)
        {
            SFXSource = GetComponent<AudioSource>();
        }

        hp = health.Value;
        prevHP = hp;
    }

    private void Update()
    {
        if(prevHP > hp)
        {
            int rnd = Random.Range(0, hitSounds.Clips.Length);

            SFXSource.clip = hitSounds.Clips[rnd];
            SFXSource.Play();
            prevHP = hp;
            controller.escape = true;
        }

        if (hp <= 0)
        {
            hp = 0;
            gameObject.SetActive(false);
        }
    }
}
