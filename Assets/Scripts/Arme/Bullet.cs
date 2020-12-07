using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public Animator Animator;

    [SerializeField] public int dommage = 10; //mettre sur vieEnnemie

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player" && collision.transform.tag != "Bullet" && collision.transform.tag != "Objet" && collision.transform.tag != "ZoneActivable" && collision.transform.tag != "BulletIgnore") 
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Animator.SetBool("aTouche", true);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
    }

}
