using UnityEngine;
using UnityEngine.UI;

public class Emplacement : MonoBehaviour
{
    public Item item = null;
    [SerializeField]
    Image emplacementItem;
    public bool isSelected;

    public void Awake()
    {
        Selected();
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
