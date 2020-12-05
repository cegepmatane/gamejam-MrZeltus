using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Niveau : MonoBehaviour
{
    public GameObject[] availibleRoom;

    public GameObject[] availiblePlayRoom;
    private GameObject[] availibleBossRoom;

    public int levelSize = 10;
    public GameObject[,] rooms;

    private GameObject currentRoom;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerateRoom()
    {
        FindAvailibleRoom();
        Vector2Int positionSpawn = new Vector2Int(0, 0);

        for (int i = 0; i < levelSize; i++)
        {
            if (currentRoom != null)
            {
                int random = Random.Range(0, 4);
                switch (random)
                {
                    case 1:
                        //Vers le haut
                        positionSpawn = new Vector2Int((int)currentRoom.transform.position.x + 15, (int)currentRoom.transform.position.y);
                        break;
                    case 2:
                        //Vers le bas
                        positionSpawn = new Vector2Int((int)currentRoom.transform.position.x - 15, (int)currentRoom.transform.position.y);
                        break;
                    case 3:
                        //Vers la droite
                        positionSpawn = new Vector2Int((int)currentRoom.transform.position.x, (int)currentRoom.transform.position.y + 15);
                        break;
                    case 4:
                        //Vers la gauche
                        positionSpawn = new Vector2Int((int)currentRoom.transform.position.x, (int)currentRoom.transform.position.y - 15);
                        break;
                    default:
                        break;
                }
            }
            int randomRoom = Random.Range(0, availibleRoom.Length);
            currentRoom = Instantiate(availibleRoom[randomRoom], new Vector3(positionSpawn.x, positionSpawn.y, 0), Quaternion.identity);


        }
    }

    private static void FindAvailibleRoom()
    {
        
    }
}
