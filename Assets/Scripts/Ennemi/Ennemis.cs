using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Ennemis : MonoBehaviour
{
    public Transform target;

    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath;

    Seeker seeker;
    Rigidbody2D rb;
    private void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        //seeker.StartPath(rb.position, target.position,OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        //if (!p.error)
        //{
          //  path = p;
        //}

    }

    private void Update()
    {
       
    }

}
