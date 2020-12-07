using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GameManager : MonoBehaviour
{
    private bool doOnce = false;
    public static GameManager Instance;
    Vector2Int start = new Vector2Int(0, 0);
    CasePortail.TypePortail typePortail;
    Room firstRoom;
    public Room currentRoom;
    Room newCurrentRoom;
    Grille grilleActuelle;
    [SerializeField]
    Transform player;
    List<Room> allRooms;
    GameObject[] objects;
    GameObject[] ennemies;
    GameObject[] coins;
    public FadeInOut fade;
    public AstarPath pathfinder;
    public GameObject computer;

    public GameObject bossRoom1;
    public GameObject bossRoom2;

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
        GetObjects();
        yield return new WaitForSeconds(1f);
        DeactivateAllRoom(newCurrentRoom);
        MoveRoom(newCurrentRoom);
        currentRoom = newCurrentRoom;
        MovePlayer();
        fade.fadeOut(1);
        doOnce = false;
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
        if(currentRoom.isClear == true)
        {
            if(doOnce == false)
            {
                ActiverPortaille();
                doOnce = true;
            }
        }
    }

    internal void SetupGame(List<Room> spawnedRoom)
    {
        allRooms = spawnedRoom;
        foreach (Room room in spawnedRoom)
        {
            room.victoire = computer;
        }
        GetFirstRoom();
        DeactivateAllRoom(firstRoom);
        MoveRoom(firstRoom);
        currentRoom = firstRoom;
        ActivatePortal();
        SpawnPlayer();
    }

    private void ActivatePortal()
    {
        Grille laGrille = currentRoom.transform.GetComponent<Grille>();
        foreach (CasePortail portail in laGrille.portails)
        {
                portail.LoadCollider();
                
        }
    }
    private void ActiverPortaille()
    {
        Grille laGrille = currentRoom.transform.GetComponent<Grille>();
        foreach (CasePortail portail in laGrille.portails)
        {
            portail.isOpen = currentRoom.isClear;

        }
    }
    void GetObjects()
    {
        GetCoin();
        GetItem();
        GetEnnemie();
    }
    void GetItem()
    {
        objects = GameObject.FindGameObjectsWithTag("Objet");
        foreach (GameObject item in objects)
        {
            if(item.transform.parent == null)
            {
                item.transform.parent = currentRoom.transform;
            }
        }
    }
    void GetEnnemie()
    {
        ennemies = GameObject.FindGameObjectsWithTag("Ennemi");
        foreach (GameObject item in ennemies)
        {
            if (item.transform.parent == null)
            {
                item.transform.parent = currentRoom.transform;
            }
        }
    }
    void GetCoin()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        foreach (GameObject item in coins)
        {
            if (item.transform.parent == null)
            {
                item.transform.parent = currentRoom.transform;
            }
        }
    }
}
