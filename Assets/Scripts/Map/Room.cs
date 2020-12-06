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



    public Room northRoom = null;
    public Room southRoom = null;
    public Room eastRoom = null;
    public Room westRoom = null;

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

            }
        }
    }

}
