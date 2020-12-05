using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public string roomName;
    public enum RoomType { EnnemieRoom, BossRoom, ItemRoom };
    public RoomType typeRoom;

    public bool openNorth = true;
    public bool openSouth = true;
    public bool openEast = true;
    public bool openWest = true;

}
