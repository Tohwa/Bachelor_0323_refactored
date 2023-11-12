using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public FloatReference FireDelay;
    public FloatReference BulletVelocity;

    public GameObject bulletPrefab;

    private bool canFire;

    private void Update()
    {
        StartCoroutine(ShotDelay());
    }

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if(canFire)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                Rigidbody rb = bullet.GetComponent<Rigidbody>();

                rb.AddForce(transform.forward * BulletVelocity.Value, ForceMode.Impulse);
            }
        }
    }

    public IEnumerator ShotDelay()
    {
        canFire = false;
        yield return new WaitForSeconds(FireDelay.Value);
        canFire = true;
    }
}
