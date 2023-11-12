using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public FloatReference MoveSpeed;

    public Vector2 MoveVector { get; private set; }

    public void Update()
    {       
        transform.Translate(MoveVector.x * MoveSpeed.Value * Time.deltaTime, 0, MoveVector.y * MoveSpeed.Value * Time.deltaTime);       
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        MoveVector = ctx.ReadValue<Vector2>();
    }
}
