using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirer : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    [SerializeField]
    private float cadenceDeTir = 0.4f; // cadence de tire, le spred, le monbre de balle, les degas

    private float lastShot;

    void Update()
    {
        float time = Time.time;
        if (time - lastShot >= cadenceDeTir)
        {
            lastShot = time;
            if(Input.GetButton("Fire1"))
            {
                Tire();
            }
        }
    }

    void Tire()
    {

        GameObject bullet = new GameObject();
        for (int i = 0; i < 4; i++)
        {
            float firepointNx = firePoint.up.x - 0.3f;
            float firepointPx = firePoint.up.x + 0.3f;
            float firepointNy = firePoint.up.y - 0.3f;
            float firepointPy = firePoint.up.y + 0.3f;
            Vector3 rotationx = firePoint.up;
            Vector3 rotationy = firePoint.up;
            float anglex = Random.Range(firepointNx, firepointPx);
            float angley = Random.Range(firepointNy, firepointPy);
            rotationx.x += anglex;
            rotationy.y += angley;
            Vector3 rotation = new Vector3(rotationx.x, rotationy.y, 0.0f);
            bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(rotation * bulletForce, ForceMode2D.Impulse);
        }

        
    }
}
