using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    public Animator Animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player") 
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Debug.Log(collision.transform.gameObject);
            Animator.SetBool("aTouche", true);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
    }

}
