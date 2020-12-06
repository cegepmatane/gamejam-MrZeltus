using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasePortail : Case
{
    public enum TypePortail {North,South,West,East}
    public TypePortail typePortail;
    public int size =1;
    CircleCollider2D collider;

    public void LoadCollider()
    {
        collider = transform.GetComponent<CircleCollider2D>();
        collider.enabled= true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collider.enabled = false;
        if (collision.transform.tag == "Player")
        {
            GameManager.Instance.ChangeRoom(transform.gameObject);
        }
    }
}
