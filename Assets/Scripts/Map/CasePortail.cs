using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasePortail : Case
{
    public enum TypePortail {North,South,West,East}
    public TypePortail typePortail;
    public int size =1;
    CircleCollider2D collider;
    bool asDone;

    public void LoadCollider()
    {
        collider = transform.GetComponent<CircleCollider2D>();
        collider.enabled= true;
        if(!asDone)
            ChangeRotation();
    }

    private void ChangeRotation()
    {
        if (typePortail == TypePortail.East)
        {
            transform.Rotate(0, 0, 90);
        }
        if (typePortail == TypePortail.North)
        {
            transform.Rotate(0, 0, 180);
        }
        if (typePortail == TypePortail.West)
        {
            transform.Rotate(0, 0, 270);
        }
        asDone = true;
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
