using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public FloatReference MoveSpeed;

    public Vector2 MoveVector { get; private set; }

    [SerializeField] private AudioSource SFXSource;

    [SerializeField] private AudioData movement;

    private float footStepTimer = 0;

    public void Update()
    {
        if(Time.timeScale != 0)
        {
            transform.Translate(MoveVector.x * MoveSpeed.Value * Time.deltaTime, 0, MoveVector.y * MoveSpeed.Value * Time.deltaTime);
        }

        if(MoveVector.x != 0 && footStepTimer <= 0  || MoveVector.y != 0 && footStepTimer <= 0)
        {
            int rnd = Random.Range(0, movement.Clips.Length);

            SFXSource.clip = movement.Clips[rnd];
            SFXSource.Play();

            footStepTimer = 1;
        }

        footStepTimer -= Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        MoveVector = ctx.ReadValue<Vector2>();
    }
}
