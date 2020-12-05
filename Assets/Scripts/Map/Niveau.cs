using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveau : MonoBehaviour
{
    public GameObject[] availibleRoom;

    public List<GameObject> availiblePlayRoom;
    private List<GameObject> availibleBossRoom = new List<GameObject>();
    private List<int> isDirectionAvailible;

    public int levelSize = 10;
    public GameObject[,] rooms;

    private GameObject currentRoom;

    // Start is called before the first frame update
    void Start()
    {
        FindAvailibleRoom();
        GenerateRoom();
    }

    void GenerateRoom()
    {
        Vector2Int positionSpawn = new Vector2Int(0, 0);

        for (int i = 0; i <= levelSize; i++)
        {
            bool openEast = true, openWest = true, openNorth = true, openSouth = true;

            if (currentRoom != null)
            {
                Room room = currentRoom.GetComponent<Room>();
                isDirectionAvailible = CheckDirection(room);
                int random = Random.Range(0, isDirectionAvailible.Count);
                int number = isDirectionAvailible[random];
                switch (random)
                {
                    case 1:
                        //Vers la droite
                        positionSpawn = new Vector2Int((int)currentRoom.transform.position.x + 15, (int)currentRoom.transform.position.y);
                        room.openEast = false;
                        openWest = false;

                        break;
                    case 2:
                        //Vers la gauche
                        positionSpawn = new Vector2Int((int)currentRoom.transform.position.x - 15, (int)currentRoom.transform.position.y);
                        room.openWest = false;
                        openEast = false;
                        break;
                    case 3:
                        //Vers le haut
                        positionSpawn = new Vector2Int((int)currentRoom.transform.position.x, (int)currentRoom.transform.position.y + 15);
                        room.openNorth = false;
                        openSouth = false;

                        break;
                    case 4:
                        //Vers le bas
                        positionSpawn = new Vector2Int((int)currentRoom.transform.position.x, (int)currentRoom.transform.position.y - 15);
                        room.openSouth = false;
                        openNorth = false;
                        break;
                    default:
                        break;
                }
            }
            if(i == levelSize)
            {
                int randomRoom = Random.Range(0, availibleBossRoom.Count);
                currentRoom = Instantiate(availibleBossRoom[randomRoom], new Vector3(positionSpawn.x, positionSpawn.y, 0), Quaternion.identity);
            }
            else
            {
                int randomRoom = Random.Range(0, availiblePlayRoom.Count);
                currentRoom = Instantiate(availiblePlayRoom[randomRoom], new Vector3(positionSpawn.x, positionSpawn.y, 0), Quaternion.identity);
            }
            currentRoom.GetComponent<Room>().openEast = openEast;
            currentRoom.GetComponent<Room>().openNorth = openNorth;
            currentRoom.GetComponent<Room>().openWest = openWest;
            currentRoom.GetComponent<Room>().openSouth = openSouth;

        }
    }

    private List<int> CheckDirection(Room room)
    {
        List<int> direction = new List<int>();
        if (room.openNorth)
        {
            direction.Add(3);
        }
        if (room.openSouth)
        {
            direction.Add(4);
        }
        if (room.openEast)
        {
            direction.Add(1);
        }
        if (room.openWest)
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
}
