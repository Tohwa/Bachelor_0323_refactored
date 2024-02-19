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

            if (gameObject.CompareTag("Weak"))
            {
                Transform childTransform = gameObject.transform.GetChild(0);
                ActivationCheck activationCheck = childTransform.GetComponent<ActivationCheck>();
                activationCheck.SetDeactivated();
                hp = weakDurability.Value;
            }
            else if (gameObject.CompareTag("Strong"))
            {
                Transform childTransform = gameObject.transform.GetChild(0);
                ActivationCheck activationCheck = childTransform.GetComponent<ActivationCheck>();
                activationCheck.SetDeactivated();
                hp = solidDurability.Value;
            }
            else if (gameObject.CompareTag("Strong"))
            {
                Transform childTransform = gameObject.transform.GetChild(0);
                ActivationCheck activationCheck = childTransform.GetComponent<ActivationCheck>();
                activationCheck.SetDeactivated();
                hp = strongDurability.Value;
            }
        }
    }
}
