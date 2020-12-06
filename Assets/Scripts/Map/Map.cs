using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    Grille grilleMap;
    int offset = 10;
    public void LoadMap(List<Room> rooms)
    {
        foreach (Room room in rooms)
        {
            grilleMap.replaceTile(room.tileRepresentingIt, room.roomPos);
        }
    }
}
