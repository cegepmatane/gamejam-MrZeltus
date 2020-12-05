using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public SpriteRenderer image;
    public enum ItemType
    {
        Arme,
        Objet,
    }

    public ItemType itemType;

}
