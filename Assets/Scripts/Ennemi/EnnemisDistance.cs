using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisDistance : Ennemis
{
    public float distanceToShoot = 5f;
    public GameObject ennemieProjectile;
    public float projectileForce = 20f;
    public Transform shootPoint;
    [SerializeField] private float cadenceDeTir = 0.7f; // cadence de tire, le spred, le monbre de balle, les degas
    private float lastShot;
    public override void SeDeplacer()
    {
        

        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }
        float dist = Vector3.Distance(target.position, transform.position);

        if (dist  > distanceToShoot)
        {

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;
            rb.AddForce(force);
            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);
            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            float time = Time.time;
            if (time - lastShot >= cadenceDeTir)
            {
                lastShot = time;
                GameObject bullet = Instantiate(ennemieProjectile, shootPoint.position, shootPoint.rotation);
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(-shootPoint.up * projectileForce, ForceMode2D.Impulse);
            }
        }
    }
}
