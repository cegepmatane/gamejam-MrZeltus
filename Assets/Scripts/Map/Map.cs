using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public static Map Instance;
    Grille grilleMap;
    Vector2Int offsetRoom = new Vector2Int(10,10);
    public GameObject defaultTile;
    private void Awake()
    {
        if (Instance != this)
            Debug.LogError("Instance of Niveau already exist");
        Instance = this;
        grilleMap = transform.GetComponent<Grille>();
    }
    public void LoadMap(List<GameObject> rooms)
    {
        foreach (GameObject gameObject in rooms)
        {
            Room room = gameObject.GetComponent<Room>();
            GameObject tileToSpawn = room.tileRepresentingIt;
            Debug.LogError("test");
            if (room.tileRepresentingIt == null)
            {
                tileToSpawn = defaultTile;
            }
            grilleMap.replaceTile(tileToSpawn, room.roomPos + offsetRoom);
        }
    }
}
