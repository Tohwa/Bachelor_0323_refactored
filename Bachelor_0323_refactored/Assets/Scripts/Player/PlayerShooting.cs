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
    
    private bool canFire;

    private void Awake()
    {
        bulletPool = new BulletPool<Bullet>(bulletPrefab, poolSize.Value, this.transform.parent.parent);
    }

    private void Update()
    {
        //StartCoroutine(ShotDelay());
    }

    public void OnShoot(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            //if(canFire)
            //{
                Bullet temp = bulletPool.GetItem();
                Rigidbody rb = temp.GetComponent<Rigidbody>();

                rb.AddForce(transform.forward * BulletVelocity.Value, ForceMode.Impulse);
            //}
        }
    }

    public IEnumerator ShotDelay()
    {
        canFire = false;
        yield return new WaitForSeconds(FireDelay.Value);
        canFire = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.forward);
    }
}
