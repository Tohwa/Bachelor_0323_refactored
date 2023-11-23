using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictMovement : MonoBehaviour
{
    private GameObject PlayArea;
    public Collider restrictedArea;

    private void Start()
    {
        // Assuming this script is attached to the GameObject that should be restricted
        // You may need to adjust this if the script is on a different GameObject
        PlayArea = GameObject.FindGameObjectWithTag("AreaBorder");
        restrictedArea = PlayArea.GetComponent<Collider>();

        if (restrictedArea == null || !restrictedArea.isTrigger)
        {
            Debug.LogError("Please attach a trigger collider to restrict movement.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Check if the collider is the one restricting movement
        if (other == restrictedArea)
        {
            // Ensure the GameObject stays within the collider
            ClampPosition();
        }
    }

    private void ClampPosition()
    {
        // Get the position of the GameObject
        Vector3 currentPosition = transform.position;

        // Clamp the position to stay within the collider bounds
        currentPosition.x = Mathf.Clamp(currentPosition.x, restrictedArea.bounds.min.x, restrictedArea.bounds.max.x);
        currentPosition.z = Mathf.Clamp(currentPosition.z, restrictedArea.bounds.min.z, restrictedArea.bounds.max.z);

        // Apply the clamped position
        transform.position = currentPosition;
    }
}
