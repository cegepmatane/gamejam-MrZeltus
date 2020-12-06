using System.Collections.Generic;
using UnityEngine;

public class EnnemisVie : MonoBehaviour
{
    public Ennemis ennemis;
    [SerializeField] private List<GameObject> ListeObjet = new List<GameObject>();

    [SerializeField] int EnnemieHealth = 100;

    private void OnTriggerEnter2D(Collider2D col)
    {
      if (col.transform.tag == "Bullet")
        {
            Debug.Log("l'ennemie toucher par une balle");
            EnnemieHealth -= col.transform.GetComponent<Bullet>().dommage;
            EnnemieMort();
        }  
    }
    public void EnnemieMort()
    {
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
            Instantiate(ListeObjet[dropItem], ennemis.transform.position, Quaternion.identity);
        }
    }
}
