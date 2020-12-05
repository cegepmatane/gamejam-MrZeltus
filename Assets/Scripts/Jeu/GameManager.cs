using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Room firstRoom;
    Grille grilleActuelle;
    [SerializeField]
    Transform player;
    List<Room> allRooms;
    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    public void SetupGame()
    {
       
    }
    void GetFirstRoom()
    {
        Debug.Log(Niveau.Instance.spawnedRoom.Count);
        firstRoom = Niveau.Instance.spawnedRoom[0];
    }
    void SpawnPlayer()
    {
        grilleActuelle = firstRoom.transform.GetComponent<Grille>();
        player.position = grilleActuelle.GridToWorld(new Vector2Int(7,7));

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetupGame(List<Room> spawnedRoom)
    {
        Debug.Log("Number of room"+ spawnedRoom.Count);
        //allRooms = spawnedRoom;
        //GetFirstRoom();
        //SpawnPlayer();
    }
}
