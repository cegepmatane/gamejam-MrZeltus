using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string roomName;
    public enum RoomType { EnnemieRoom, BossRoom, ItemRoom };
    public RoomType typeRoom;
    public Vector2Int roomPos;


    public Room northRoom = null;
    public Room southRoom = null;
    public Room eastRoom = null;
    public Room westRoom = null;

}
