using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float fireRate = 0.2f;
    public static int bulletNumber = 3;
    float timeUntilFire ;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && timeUntilFire < Time.time && bulletNumber > 0)
        {
            Shoot();
            bulletNumber -= 1;
            timeUntilFire = Time.time + fireRate;
        }
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position,firePoint.rotation);
        AudioManager.instance.PlaySound("Throwing");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terlik"))
        {
            Destroy(collision.gameObject);
            bulletNumber += 1;
        }
    }


}
