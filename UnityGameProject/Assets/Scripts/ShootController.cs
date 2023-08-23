using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float shootingForce = 10f;
    public float shootingRate = 0.2f;
    public float bulletLifetime = 5f;  // Lifetime of bullets in seconds

    private float nextShotTime = 0f;

    void Update()
    {
        if (Time.time > nextShotTime)
        {
            Shoot();
            nextShotTime = Time.time + shootingRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = shootingPoint.transform.position;
            bullet.transform.rotation = shootingPoint.transform.rotation;
            bullet.SetActive(true);
        }

        DestroyBulletAfterTime(bullet);
    }

    private void DestroyBulletAfterTime(GameObject bullet)
    {
        StartCoroutine(DestroyBulletCoroutine(bullet));
    }

    IEnumerator DestroyBulletCoroutine(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletLifetime);
        //Destroy(bullet);
        bullet.SetActive(false);

    }
}





