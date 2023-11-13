using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPoolable<Bullet>
{
    private BulletPool<Bullet> pool;

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void InitializeBullet(BulletPool<Bullet> _pool)
    {
        pool = _pool;
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (pool != null)
        {
            pool.ReturnItem(this);
        }
    }
}
