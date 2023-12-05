using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Kugel
    public FloatReference bulletForce; // Fluggeschwindigkeit
    public FloatReference shootDelay;
    public bool canShoot = true;

    public void Start()
    {
        StartCoroutine(ShotDelay());
    }

    public void Shoot()
    {
        if(canShoot) 
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * bulletForce.Value, ForceMode.Impulse);
        }

    }

    public IEnumerator ShotDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootDelay.Value);
        canShoot = true;
    }
}
