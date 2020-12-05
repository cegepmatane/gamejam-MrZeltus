using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour
{
    [SerializeField]
    private Emplacement[] emplacementList;


        public Item item;

        public void Start()
    {
        recuperer(item);
        Debug.Log(emplacementList.Length);
    }
    public void recuperer(Item item)
    {
        for (int i = 0; i < emplacementList.Length; i++)
        {
            if (emplacementList[i].item == null && emplacementList[i].typeEmplacement.ToString() == item.itemType.ToString())
            {
                emplacementList[i].item = item;
                emplacementList[i].afficher();
                item.transform.gameObject.SetActive(false);
                return;
            }
        }
    }

    public void selectionner()
    {

    }
}
