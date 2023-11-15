using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public FloatReference FireDelay;
    public FloatReference BulletVelocity;
    public IntReference poolSize;

    public GameObject bulletPrefab;

    private BulletPool<Bullet> bulletPool;
    
    private void Awake()
    {
        bulletPool = new BulletPool<Bullet>(bulletPrefab, poolSize.Value, transform.parent.parent);
    }

    private void Update()
    {

    }

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            ShootBullet();                            
        }
    }

    private void ShootBullet()
    {
        Bullet temp = bulletPool.GetItem();
        Rigidbody rb = temp.GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * BulletVelocity.Value, ForceMode.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.forward);
    }
}
