using UnityEngine;

public class Inventaire : MonoBehaviour
{
    [SerializeField]
    private Emplacement[] emplacementList;
    public static Inventaire Instance;

    

    public Item item;

    public void Start()
    {
        Instance = this;
    }
    public void Recuperer(Item item)
    {
        
        for (int i = 0; i < emplacementList.Length; i++)
        {
            if (emplacementList[i].item == null && emplacementList[i].typeEmplacement.ToString() == item.itemType.ToString())
            {
                emplacementList[i].item = item;
                emplacementList[i].Afficher();
                item.transform.gameObject.SetActive(false);
                return;
            }
        }
    }

    public void Selectionner(Emplacement emplacement)
    {
        for (int i = 0; i < emplacementList.Length; i++)
        {
            if (emplacementList[i] == emplacement && (emplacementList[i].typeEmplacement.ToString() == "Arme" && emplacement.typeEmplacement.ToString() == "Arme"))
            {
                emplacementList[i].isSelected = true;
            }
            else if (emplacementList[i].typeEmplacement.ToString() == "Arme" && emplacement.typeEmplacement.ToString() == "Arme")
            {
                emplacementList[i].isSelected = false;
            }
            else if (emplacementList[i] == emplacement && (emplacementList[i].typeEmplacement.ToString() == "Objet" && emplacement.typeEmplacement.ToString() == "Objet"))
            {
                emplacementList[i].isSelected = true;
            }
            else if (emplacementList[i].typeEmplacement.ToString() == "Objet" && emplacement.typeEmplacement.ToString() == "Objet")
            {
                emplacementList[i].isSelected = false;
            }
            emplacementList[i].Selected();
        }
    }

    public void Jetter(Emplacement emplacement)
    {

        for (int i = 0; i < emplacementList.Length; i++)
        {
            if (emplacementList[i] == emplacement && emplacementList[i].item != null)
            {

                emplacementList[i].NePlusAfficher();
                emplacementList[i].item.transform.gameObject.SetActive(true);
                emplacementList[i].item = null;
                return;
            }
        }
    }

    public void detruireItem(Emplacement emplacement,Item item)
    {
        emplacement.NePlusAfficher();
        emplacement.item = null;
        Destroy(item.gameObject);
    }

    public void UtiliserItem()
    {
        for (int i = 0; i < emplacementList.Length; i++)
        {
            if (emplacementList[i].item != null && emplacementList[i].isSelected == true && emplacementList[i].typeEmplacement.ToString() == "Objet")
            {
                emplacementList[i].item.utiliser();
                detruireItem(emplacementList[i], emplacementList[i].item);
            }
        }
    }
    public void UtiliserArme()
    {
        for (int i = 0; i < emplacementList.Length; i++)
        {
            if (emplacementList[i].item != null && emplacementList[i].isSelected == true && emplacementList[i].typeEmplacement.ToString() == "Arme")
            {
                string nom = emplacementList[i].item.name;
                Debug.Log(nom);
                emplacementList[i].item.attaquer(); // recuperer le nom de l'arme et de l'objet
            }
        }
    }
}
