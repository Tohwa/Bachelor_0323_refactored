using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHealthCounter : MonoBehaviour
{
    [SerializeField] private GameObjectSet sheepSet;
    [SerializeField] private GameObject heartOne;
    [SerializeField] private GameObject heartTwo;
    [SerializeField] private GameObject heartThree;
    [SerializeField] private GameObject heartFour;


    private void Update()
    {
        switch (sheepSet.Items.Count)
        {
            case 0:
                {
                    heartOne.SetActive(false);
                    heartTwo.SetActive(false);
                    heartThree.SetActive(false);
                    heartFour.SetActive(false);
                    break;
                }
            case 1:
                {
                    heartOne.SetActive(true);
                    heartTwo.SetActive(false);                        
                    heartThree.SetActive(false);
                    heartFour.SetActive(false);
                    break;
                }
            case 2:
                {
                    heartOne.SetActive(true);
                    heartTwo.SetActive(true);
                    heartThree.SetActive(false);
                    heartFour.SetActive(false);
                    break;
                }
            case 3:
                {
                    heartOne.SetActive(true);
                    heartTwo.SetActive(true);
                    heartThree.SetActive(true);
                    heartFour.SetActive(false);
                    break;
                }
            case 4:
                {
                    heartOne.SetActive(true);
                    heartTwo.SetActive(true);
                    heartThree.SetActive(true);
                    heartFour.SetActive(true);
                    break;
                }
        }
    }
}
