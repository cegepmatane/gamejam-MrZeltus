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
        firstRoom = Niveau.Instance.spawnedRoom[0];
    }
    void SpawnPlayer()
    {
        grilleActuelle = firstRoom.transform.GetComponent<Grille>();
        player.position = grilleActuelle.GridToWorld(new Vector2Int(7,7));

    }
    void DeactivateAllRoom(Room baseRoom)
    {
        foreach (Room room in allRooms)
        {
            if(room != baseRoom)
            {
                room.transform.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void SetupGame(List<Room> spawnedRoom)
    {
        allRooms = spawnedRoom;
        GetFirstRoom();
        DeactivateAllRoom(firstRoom);
        SpawnPlayer();
    }
}
