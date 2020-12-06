using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemisDistance : Ennemis
{
    public float distanceToShoot = 5f;
    public GameObject ennemieProjectile;
    public float projectileForce = 20f;
    public Transform shootPoint;
    public override void SeDeplacer()
    {
        shootPoint.LookAt(target.position);
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
        Debug.Log(dist - 25 < distanceToShoot);
        if (dist - 25 > distanceToShoot)
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
            GameObject bullet = Instantiate(ennemieProjectile, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(shootPoint.up * projectileForce, ForceMode2D.Impulse);
        }
    }
}
