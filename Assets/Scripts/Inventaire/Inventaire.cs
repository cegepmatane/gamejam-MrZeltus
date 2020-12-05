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
            Recuperer(item);
            Debug.Log(emplacementList.Length);
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

    public void Jetter()
    {
        for (int i = 0; i < emplacementList.Length; i++)
        {
            if (emplacementList[i].item != null)
            {
                emplacementList[i].item = null;
                emplacementList[i].NePlusAfficher();
                item.transform.gameObject.SetActive(true);
                return;
            }
        }
    }
}
