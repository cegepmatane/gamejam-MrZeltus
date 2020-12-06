using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirer : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int Degats = 10;

    public float bulletForce = 20f;
    
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Tire();
        }
    }

    void Tire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
