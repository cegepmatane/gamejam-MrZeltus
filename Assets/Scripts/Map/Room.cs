using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string roomName;
    public enum RoomType {EnnemieRoom,BossRoom,ItemRoom,CoinRoom };
    public RoomType typeRoom;
    public Vector2Int roomPos;
    public bool isClear =false;
    public List<Ennemis> ennemis;
    public GameObject computer;
    public List<Case> availlibleSpawnCase;

    public GameObject tileRepresentingIt;

    private bool isDone = false;

    public Room northRoom = null;
    public Room southRoom = null;
    public Room eastRoom = null;
    public Room westRoom = null;

    public void Start()
    {
        findAvaillibleSpawn();
    }

    private void findAvaillibleSpawn()
    {
        Case[] tuiles = transform.GetComponent<Grille>().TilesList;
        foreach (Case tuile in tuiles)
        {
            if (tuile.typeCase == Case.CaseType.Sol)
            {
                availlibleSpawnCase.Add(tuile);
            }
        }
    }

    private void Update()
    {
        if(ennemis.Count == 0)
        {
            isClear = true;
        }
        if (isClear)
        {
            if(typeRoom == RoomType.BossRoom)
            {
                if(isDone == false)
                {
                    int random = UnityEngine.Random.Range(0, availlibleSpawnCase.Count);
                    Vector3 position = transform.GetComponent<Grille>().GridToWorld(availlibleSpawnCase[random].GridPos);
                    position.z = -0.5f;
                    Instantiate(computer, position, Quaternion.identity);
                    isDone = true;
                }
               
                
            }
        }
    }

}
