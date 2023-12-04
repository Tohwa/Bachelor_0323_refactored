using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public FloatReference FireDelay;
    public IntReference poolSize;
    public FloatReference BulletVelocity;

    public GameObject bulletPrefab;

    private BulletPool<Bullet> bulletPool;

    private bool canFire;
    
    private void Awake()
    {
        bulletPool = new BulletPool<Bullet>(bulletPrefab, poolSize.Value, transform.parent.parent);
    }

    private void Update()
    {
        if(canFire)
        {
            ShootBullet();
        }
    }

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            canFire = true;                           
        }
        else if(ctx.canceled)
        {
            canFire = false;
        }
    }

    private void ShootBullet()
    {
        Bullet temp = bulletPool.GetItem();
        Rigidbody rb = temp.GetComponent<Rigidbody>();

        temp.transform.position = transform.position;

        rb.AddForce(transform.forward * BulletVelocity.Value, ForceMode.Impulse);
    }
}
