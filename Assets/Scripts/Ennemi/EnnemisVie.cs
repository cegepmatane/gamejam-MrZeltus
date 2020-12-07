using System.Collections.Generic;
using UnityEngine;

public class EnnemisVie : MonoBehaviour
{
    public Ennemis ennemis;
    [SerializeField] private List<GameObject> ListeObjet = new List<GameObject>();

    [SerializeField] int EnnemieHealth = 100;


    public void Awake()
    {
        ennemis = transform.GetComponent<Ennemis>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
      if (col.transform.tag == "Bullet")
        {
       
            EnnemieHealth -= col.transform.GetComponent<Bullet>().dommage;
            EnnemieMort();
        }  
    }
    public void EnnemieMort()
    {
        GameManager.Instance.currentRoom.currentRoomEnnemie.Remove(transform.GetComponent<Ennemis>());
        if(EnnemieHealth <= 0)
        {
            DropObjet();
            Destroy(ennemis.gameObject);
        }
    }
    
    public void DropObjet()
    { 
        float dropRate = 0.25f;
        float dropChance = Random.Range(0, 1);
        if(dropChance <= dropRate)
        {
            int dropItem = Random.Range(0, ListeObjet.Count);
            GameObject objetInstancier = Instantiate(ListeObjet[dropItem], ennemis.transform.position, Quaternion.identity);
            JetterObjet.Instance.LancerObjet(objetInstancier.GetComponent<Item>(), ennemis.transform.position);
        }
    }
}
