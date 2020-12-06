using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirerLaser : MonoBehaviour
{
    public GameObject hitEffect;
    public int Degats = 3;

    public Animator Animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag != "Player")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Animator.SetBool("aTouche", true);
            Destroy(effect, 5f);
            Destroy(gameObject);
        }
    }

}
