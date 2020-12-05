using UnityEngine;
using UnityEngine.UI;

public class Emplacement : MonoBehaviour
{
    
    [SerializeField]
    Image emplacementItem;
    [SerializeField]
    Sprite transparent;

    public Item item = null;
    public bool isSelected;
    public static Emplacement Instance;

    public void Awake()
    {
        Selected();
        Instance = this;
    }
    public enum TypeEmplacement
    {
        Arme,
        Objet,
    }
    public TypeEmplacement typeEmplacement;

    public void Afficher()
    {
        emplacementItem.sprite = item.transform.gameObject.GetComponent<SpriteRenderer>().sprite;
    }
    public void NePlusAfficher()
    {
        emplacementItem.sprite = transparent;
    }

    public void Selected()
    {
        if(isSelected == false)
        {
            GetComponent<Image>().color = new Color32(96, 96, 96, 255);
        }
        else
        {
            GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
}
