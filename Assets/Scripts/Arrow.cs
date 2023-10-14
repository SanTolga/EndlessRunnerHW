using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletForce = 15f;
    private bool canFire = true;

    private void Update()
    {
        if (canFire)
        {
            ThrowBullet();
        }
    }

    private void ThrowBullet()
    {
        GameObject newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, quaternion.Euler(0,180,0));

        Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();

        bulletRb.AddForce(bulletSpawnPoint.forward * bulletForce, ForceMode.Impulse);

        // Prevent firing again until the next input
        canFire = false;
        StartCoroutine(EnableFire());
    }

    IEnumerator EnableFire()
    {
        // Allow firing again after a short delay (e.g., 0.5 seconds)
        yield return new WaitForSeconds(2f);
        canFire = true;
    }
}