using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveau : MonoBehaviour
{
    public static Niveau Instance;

    public List<GameObject> availibleRoom;
    public GameObject tilePortail;
    private List<GameObject> availiblePlayRoom = new List<GameObject>();
    private List<GameObject> availibleBossRoom = new List<GameObject>();

    private List<int> isDirectionAvailible;

    public int levelSize = 10;
    public GameObject[,] rooms;
    private int offsetArray = 500;
    public Vector2Int currentRoomPos;

    public List<Room> spawnedRoom;

    private GameObject currentRoom;
    public void Awake()
    {
        if (Instance != this)
            Debug.LogError("Instance of Niveau already exist");
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rooms = new GameObject[(levelSize+offsetArray)*2,(levelSize+ offsetArray)*2];
        FindAvailibleRoom();
        GenerateRoom();
        SpawnPortail();
        //Map.Instance.LoadMap(availibleRoom);
    }

    void GenerateRoom()
    {
        currentRoomPos = new Vector2Int(0, 0);
        Vector2Int positionSpawn = new Vector2Int(0, 0);
        Room pastRoom = new Room();

        for (int i = 0; i <= levelSize; i++)
        {
            if (currentRoom != null)
            {
                pastRoom = currentRoom.GetComponent<Room>();
            }
            bool openEast = true, openWest = true, openNorth = true, openSouth = true;

            if (currentRoom != null)
            {
                isDirectionAvailible = CheckDirection(pastRoom);
                int random = Random.Range(0, isDirectionAvailible.Count);
                int number = isDirectionAvailible[random];

                switch (number)
                {
                    case 1:
                        //Vers la droite
                        positionSpawn = new Vector2Int((int)currentRoom.transform.position.x + 15, (int)currentRoom.transform.position.y);
                        currentRoomPos.x += 1;
                        openWest = false;

                        break;
                    case 2:
                        //Vers la gauche
                        positionSpawn = new Vector2Int((int)currentRoom.transform.position.x - 15, (int)currentRoom.transform.position.y);
                        currentRoomPos.x -= 1;
                        openEast = false;
                        break;
                    case 3:
                        //Vers le haut
                        positionSpawn = new Vector2Int((int)currentRoom.transform.position.x, (int)currentRoom.transform.position.y + 15);
                        currentRoomPos.y += 1;
                        openSouth = false;
                        break;
                    case 4:
                        //Vers le bas
                        positionSpawn = new Vector2Int((int)currentRoom.transform.position.x, (int)currentRoom.transform.position.y - 15);
                        currentRoomPos.y -= 1;
                        openNorth = false;
                        break;
                    default:
                        break;
                }
            }
            if(i == levelSize)
            {
                if (availibleBossRoom.Count != 0)
                {
                    int randomRoom = Random.Range(0, availibleBossRoom.Count);
                    currentRoom = Instantiate(availibleBossRoom[randomRoom], new Vector3(positionSpawn.x, positionSpawn.y, 0), Quaternion.identity);
                }
                else
                {
                    currentRoom = Instantiate(availibleBossRoom[0], new Vector3(positionSpawn.x, positionSpawn.y, 0), Quaternion.identity);
                }
            }
            else
            {
                int randomRoom = Random.Range(0, availiblePlayRoom.Count);
                currentRoom = Instantiate(availiblePlayRoom[randomRoom], new Vector3(positionSpawn.x, positionSpawn.y, 0), Quaternion.identity);
            }
            currentRoom.GetComponent<Room>().roomPos = currentRoomPos;
            spawnedRoom.Add(currentRoom.GetComponent<Room>());
            Vector2Int currentRoomOffset = new Vector2Int(currentRoomPos.x + offsetArray, currentRoomPos.y + offsetArray);

            rooms[currentRoomOffset.x, currentRoomOffset.y] = currentRoom;
            CheckForRoom(currentRoom.GetComponent<Room>(),currentRoomOffset);


        }
        foreach (Room room in spawnedRoom)
        {
            Vector2Int currentRoomOffset = new Vector2Int(room.roomPos.x + offsetArray, room.roomPos.y + offsetArray);
            CheckForRoom(room, currentRoomOffset);
        }
        GameManager.Instance.SetupGame(spawnedRoom);
    }

    private void CheckForRoom(Room room,Vector2Int position)
    {
       if(rooms[position.x+1, position.y] != null)
        {
            room.eastRoom = rooms[position.x + 1, position.y].GetComponent<Room>();
        }
        if (rooms[position.x - 1, position.y] != null)
        {
            room.westRoom = rooms[position.x - 1, position.y].GetComponent<Room>();
        }
        if (rooms[position.x, position.y+1] != null)
        {
            room.northRoom = rooms[position.x, position.y+1].GetComponent<Room>();
        }
        if (rooms[position.x, position.y - 1] != null)
        {
            room.southRoom = rooms[position.x, position.y-1].GetComponent<Room>();
        }
    }
    private List<int> CheckDirection(Room room)
    {
        List<int> direction = new List<int>();
        if (room.northRoom == null)
        {
            direction.Add(3);
        }
        if (room.southRoom == null)
        {
            direction.Add(4);
        }
        if (room.eastRoom == null)
        {
            direction.Add(1);
        }
        if (room.westRoom == null)
        {
            direction.Add(2);
        }
        return direction;
    }

    private void FindAvailibleRoom()
    {
        foreach (GameObject room in availibleRoom)
        {
            if(room.GetComponent<Room>().typeRoom.ToString() == "EnnemieRoom")
            {
                availiblePlayRoom.Add(room);
            }
            if (room.GetComponent<Room>().typeRoom.ToString() == "BossRoom")
            {
                availibleBossRoom.Add(room);
            }

        }
    }


    

    private void SpawnPortail()
    {
        foreach (Room room in spawnedRoom)
        {
            if(room.northRoom == true)
            {
                CasePortail.TypePortail type = CasePortail.TypePortail.South;
                Grille grilleActuel = room.transform.GetComponent<Grille>();
                Vector2Int pos = new Vector2Int(7, grilleActuel.RowCount-1);
                grilleActuel.replaceTile(tilePortail, pos,type);
            }
            if (room.southRoom == true)
            {
                CasePortail.TypePortail type = CasePortail.TypePortail.North;
                Grille grilleActuel = room.transform.GetComponent<Grille>();
                Vector2Int pos = new Vector2Int(7, 0);
                grilleActuel.replaceTile(tilePortail, pos, type);

            }
            if (room.westRoom == true)
            {
                CasePortail.TypePortail type = CasePortail.TypePortail.East;
                Grille grilleActuel = room.transform.GetComponent<Grille>();
                Vector2Int pos = new Vector2Int(0,7);
                grilleActuel.replaceTile(tilePortail, pos, type);

            }
            if (room.eastRoom == true)
            {
                CasePortail.TypePortail type = CasePortail.TypePortail.West;
                Grille grilleActuel = room.transform.GetComponent<Grille>();
                Vector2Int pos = new Vector2Int(grilleActuel.RowCount - 1, 7);
                grilleActuel.replaceTile(tilePortail, pos, type);

            }
        }
    }
}
