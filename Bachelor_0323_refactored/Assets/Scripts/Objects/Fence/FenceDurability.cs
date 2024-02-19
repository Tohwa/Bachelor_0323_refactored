using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.Events;

public class FenceDurability : MonoBehaviour
{

    public GameEvent fenceDestroyed;
    public UnityEvent destructionResponse;

    public FloatReference weakDurability;
    public FloatReference solidDurability;
    public FloatReference strongDurability;

    private float waitTimer = 3f;

    public float hp;


    public void Update()
    {
        if (gameObject.CompareTag("Weak"))
        {
            Transform childTransform = gameObject.transform.GetChild(0);
            ActivationCheck activationCheck = childTransform.GetComponent<ActivationCheck>();

            // Überprüfen, ob das Kindobjekt aktiviert wurde und zuvor inaktiv war
            if (childTransform.gameObject.activeSelf && !activationCheck.WasActivated)
            {
                hp = weakDurability.Value;

                // Setzen Sie den WasActivated-Flag auf true, um zu verhindern, dass der Code erneut ausgeführt wird
                activationCheck.SetActivated();
            }
        }
        else if (gameObject.CompareTag("Solid"))
        {
            Transform childTransform = gameObject.transform.GetChild(0);
            ActivationCheck activationCheck = childTransform.GetComponent<ActivationCheck>();

            // Überprüfen, ob das Kindobjekt aktiviert wurde und zuvor inaktiv war
            if (childTransform.gameObject.activeSelf && !activationCheck.WasActivated)
            {
                hp = solidDurability.Value;

                // Setzen Sie den WasActivated-Flag auf true, um zu verhindern, dass der Code erneut ausgeführt wird
                activationCheck.SetActivated();
            }
        }
        else if (gameObject.CompareTag("Strong"))
        {
            Transform childTransform = gameObject.transform.GetChild(0);
            ActivationCheck activationCheck = childTransform.GetComponent<ActivationCheck>();

            // Überprüfen, ob das Kindobjekt aktiviert wurde und zuvor inaktiv war
            if (childTransform.gameObject.activeSelf && !activationCheck.WasActivated)
            {
                hp = strongDurability.Value;

                // Setzen Sie den WasActivated-Flag auf true, um zu verhindern, dass der Code erneut ausgeführt wird
                activationCheck.SetActivated();
            }
        }

        if (hp <= 0)
        {
            hp = 0;

            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            gameObject.transform.GetChild(2).gameObject.SetActive(false);
            gameObject.transform.GetChild(3).gameObject.SetActive(false);

            fenceDestroyed.Raise();

            DeactivationSequence();

            waitTimer -= Time.deltaTime;
        }

        
    }

    private void DeactivationSequence()
    {
        if (gameObject.CompareTag("Weak"))
        {
            Transform childTransformOne = gameObject.transform.GetChild(0);
            Transform childTransformTwo = gameObject.transform.parent.gameObject.transform.GetChild(1).transform.GetChild(0);
            Transform childTransformThree = gameObject.transform.parent.gameObject.transform.GetChild(2).transform.GetChild(0);

            ActivationCheck activationCheckOne = childTransformOne.GetComponent<ActivationCheck>();
            ActivationCheck activationCheckTwo = childTransformTwo.GetComponent<ActivationCheck>();
            ActivationCheck activationCheckThree = childTransformThree.GetComponent<ActivationCheck>();

            activationCheckOne.SetDeactivated();
            activationCheckTwo.SetDeactivated();
            activationCheckThree.SetDeactivated();
            
            if(waitTimer <= 0)
            {
                hp = weakDurability.Value;
                waitTimer = 3f;
            }
            
        }
        else if (gameObject.CompareTag("Solid"))
        {
            Transform childTransformOne = gameObject.transform.GetChild(0);
            Transform childTransformTwo = gameObject.transform.parent.gameObject.transform.GetChild(0).transform.GetChild(0);
            Transform childTransformThree = gameObject.transform.parent.gameObject.transform.GetChild(2).transform.GetChild(0);

            ActivationCheck activationCheckOne = childTransformOne.GetComponent<ActivationCheck>();
            ActivationCheck activationCheckTwo = childTransformTwo.GetComponent<ActivationCheck>();
            ActivationCheck activationCheckThree = childTransformThree.GetComponent<ActivationCheck>();

            activationCheckOne.SetDeactivated();
            activationCheckTwo.SetDeactivated();
            activationCheckThree.SetDeactivated();

            if (waitTimer <= 0)
            {
                hp = solidDurability.Value;
                waitTimer = 3f;
            }

            
        }
        else if (gameObject.CompareTag("Strong"))
        {
            Transform childTransformOne = gameObject.transform.GetChild(0);
            Transform childTransformTwo = gameObject.transform.parent.gameObject.transform.GetChild(0).transform.GetChild(0);
            Transform childTransformThree = gameObject.transform.parent.gameObject.transform.GetChild(1).transform.GetChild(0);

            ActivationCheck activationCheckOne = childTransformOne.GetComponent<ActivationCheck>();
            ActivationCheck activationCheckTwo = childTransformTwo.GetComponent<ActivationCheck>();
            ActivationCheck activationCheckThree = childTransformThree.GetComponent<ActivationCheck>();

            activationCheckOne.SetDeactivated();
            activationCheckTwo.SetDeactivated();
            activationCheckThree.SetDeactivated();

            if (waitTimer <= 0)
            {
                hp = strongDurability.Value;
                waitTimer = 3f;
            }
            
        }
    }
}
