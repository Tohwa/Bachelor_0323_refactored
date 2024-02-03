using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("Main camera not found in the scene.");
        }
    }

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            HandleMouseInput();
        }
    }

    private void HandleMouseInput()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.black);

            LookAtPointOnGround(pointToLook);
        }
    }

    private void LookAtPointOnGround(Vector3 pointToLook)
    {
        transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
    }
}
