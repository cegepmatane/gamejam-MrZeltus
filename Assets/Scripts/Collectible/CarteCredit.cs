using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteCredit : MonoBehaviour
{
    public GameObject CoinMaster;
    public GameObject Coin; 
    public Grille grilleActuelle;
    public List<Case> TuilePlacable;
    public int coinsNum = 5;



    public void ApparitionCoins()
    {
        PlacementPossible();
        CreateCoins();
    }

    public void CreateCoins()
    {
        for (int i = 0; i < coinsNum; i++)
        {
            int tuiles = Random.Range(0, TuilePlacable.Count);
            Vector3 positionSpawn = TuilePlacable[tuiles].transform.position;
            positionSpawn.z = -1f;
            GameObject coinClone = Instantiate(Coin, positionSpawn, Quaternion.identity);
        }
    }

    private void PlacementPossible()
    {
        foreach (Case tuile in grilleActuelle.TilesList)
        {
            if (tuile.typeCase.ToString() == "Sol")
            {
                TuilePlacable.Add(tuile);
            }
        }

    }
}
