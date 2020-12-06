using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int dommage = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player" || collision.transform.tag == "Obstacle")
        {
            if(collision.transform.tag == "Player")
            {
                collision.GetComponent<ViePersonnage>().TakeDamage(5);
            }
            Destroy(this.gameObject);
        }
    }
}
