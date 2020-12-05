using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Emplacement : MonoBehaviour
{
    public Item item = null;
    public enum TypeEmplacement
    {
        Arme,
        Objet,
    }
    public TypeEmplacement typeEmplacement;

    public void afficher()
    {
        GetComponent<Image>().sprite = item.transform.gameObject.GetComponent<SpriteRenderer>().sprite;
        GetComponent<Image>().color = new Color(255, 255, 255, 100);

    }

}
