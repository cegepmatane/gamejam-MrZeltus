using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Vector2Int start = new Vector2Int(0, 0);
    CasePortail.TypePortail typePortail;
    Room firstRoom;
    Room currentRoom;
    Room newCurrentRoom;
    Grille grilleActuelle;
    [SerializeField]
    Transform player;
    List<Room> allRooms;
    public FadeInOut fade;
    public AstarPath pathfinder;
    public GameObject computer;
    public void Awake()
    {
        Instance = this;
    }
    public void Start()
    {
        player = Personnage.Instance.transform;
    }

    // Start is called before the first frame update
    public void ChangeRoom(GameObject portal)
    {
        CasePortail tuile = portal.GetComponent<CasePortail>();
        typePortail = tuile.typePortail;
        if (tuile.typePortail.ToString() == "North")
        {
            start.y -= 1;
        }
        if (tuile.typePortail.ToString() == "South")
        {
            start.y += 1;
        }
        if (tuile.typePortail.ToString() == "East")
        {
            start.x -= 1;
        }
        if (tuile.typePortail.ToString() == "West")
        {
            start.x += 1;
        }

        foreach (Room room in allRooms)
        {
            if(room.roomPos == start)
            {
                RoomChanging(room);
            }
        }
    }

    private void RoomChanging(Room room)
    {
        newCurrentRoom = room;
        StartCoroutine("Fade");
    }

    public IEnumerator Fade()
    {
        fade.fadeIn(1);
        yield return new WaitForSeconds(1f);
        DeactivateAllRoom(newCurrentRoom);
        MoveRoom(newCurrentRoom);
        currentRoom = newCurrentRoom;
        MovePlayer();
        fade.fadeOut(1);
        ActivatePortal();

    }
    private void MovePlayer()
    {
        if(typePortail.ToString() == "North")
        {
            player.position = grilleActuelle.GridToWorld(new Vector2Int(7, grilleActuelle.RowCount-3));
        }
        if (typePortail.ToString() == "South")
        {
            player.position = grilleActuelle.GridToWorld(new Vector2Int(7, 0 + 3));
        }
        if (typePortail.ToString() == "East")
        {
            player.position = grilleActuelle.GridToWorld(new Vector2Int(grilleActuelle.RowCount-3,7));
        }
        if (typePortail.ToString() == "West")
        {
            player.position = grilleActuelle.GridToWorld(new Vector2Int(0+ 3, 7));
        }
    }
    void GetFirstRoom()
    {
        firstRoom = Niveau.Instance.spawnedRoom[0];
    }
    void MoveRoom(Room room)
    {
        room.transform.position = new Vector3(0,0,0);
        pathfinder.Scan();
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
            else
            {
                room.transform.gameObject.SetActive(true);
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
        foreach (Room room in spawnedRoom)
        {
            room.computer = computer;
        }
        GetFirstRoom();
        DeactivateAllRoom(firstRoom);
        MoveRoom(firstRoom);
        currentRoom = firstRoom;
        SpawnPlayer();
        ActivatePortal();

    }

    private void ActivatePortal()
    {
        Grille laGrille = currentRoom.transform.GetComponent<Grille>();
        foreach (CasePortail portail in laGrille.portails)
        {
            portail.LoadCollider();
        }
    }
}
