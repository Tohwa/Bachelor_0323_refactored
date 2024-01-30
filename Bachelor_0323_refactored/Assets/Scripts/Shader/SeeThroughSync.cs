using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SeeThroughSync : MonoBehaviour
{
    public static int posID = Shader.PropertyToID("_playerposition");
    public static int sizeID = Shader.PropertyToID ("_size");

    public Material wallMaterial;
    public Camera camera;
    public LayerMask collisionMask;

    // Update is called once per frame
    void Update()
    {
        var dir = camera.transform.position - transform.position;
        var ray = new Ray(transform.position, dir.normalized);

        if(Physics.Raycast(ray, 3000, collisionMask))
        {
            wallMaterial.SetFloat(sizeID, 1);
        }
        else
        {
            wallMaterial.SetFloat (sizeID, 0);
        }

        var view = camera.WorldToViewportPoint(transform.position);
        wallMaterial.SetVector(posID, view);
    }
}
