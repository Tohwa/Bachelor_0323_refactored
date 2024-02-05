using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Bullet : MonoBehaviour, IPoolableBullet<Bullet>
{
    public FloatReference bulletDamage;
    [SerializeField] private GameObject impactPrefab;

    [HideInInspector] public float damage;

    private BulletPool<Bullet> pool;
    private Rigidbody rb;

    private void Start()
    {
        damage = bulletDamage.Value;
        rb = GetComponent<Rigidbody>();
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (pool != null)
        {
            pool.ReturnItem(this);

            if (other.CompareTag("Enemy") || other.CompareTag("BossEnemy"))
            {
                other.gameObject.GetComponent<EnemyHealth>().hp -= damage;

                Instantiate(impactPrefab, other.gameObject.transform);


            }
        }
    }
}
