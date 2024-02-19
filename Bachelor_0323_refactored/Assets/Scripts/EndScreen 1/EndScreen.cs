using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject winText;
    [SerializeField] private GameObject loseText;

    [SerializeField] private AudioSource SFXSource;

    [SerializeField] private AudioClip bossDeath;
    [SerializeField] private AudioData playerDeath;

    private void Start()
    {
        if(GameManager.playerDead || GameManager.sheepDead)
        {
            loseText.SetActive(true);
            winText.SetActive(false);

            int rnd = Random.Range(0, playerDeath.Clips.Length);

            SFXSource.clip = playerDeath.Clips[rnd];
            SFXSource.Play();
        }
        else if(GameManager.bossDead)
        {
            winText.SetActive(true);
            loseText.SetActive(false);

            SFXSource.clip = bossDeath;
            SFXSource.Play();
        }
    }
}
