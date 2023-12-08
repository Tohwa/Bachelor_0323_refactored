using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public FloatReference FireDelay;
    public IntReference poolSize;
    public FloatReference BulletVelocity;

    public float timeBetweenShots;

    public GameObject bulletPrefab;

    private BulletPool<Bullet> bulletPool;

    private bool canFire;

    private void Awake()
    {
        bulletPool = new BulletPool<Bullet>(bulletPrefab, poolSize.Value, transform.parent.parent);
    }

    private void Start()
    {
        timeBetweenShots = FireDelay.Value;
    }

    private void Update()
    {
        if (canFire)
        {
            timeBetweenShots -= Time.deltaTime;

            if (timeBetweenShots <= 0)
            {
                ShootBullet();
                timeBetweenShots = FireDelay.Value;
            }
        }
    }

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        canFire = ctx.performed;
    }

    private void ShootBullet()
    {
        Bullet temp = bulletPool.GetItem();
        Rigidbody rb = temp.GetComponent<Rigidbody>();

        temp.transform.position = transform.position;

        rb.AddForce(transform.forward * BulletVelocity.Value, ForceMode.Impulse);
    }
}
