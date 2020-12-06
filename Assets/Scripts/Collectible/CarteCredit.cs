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
    public List<GameObject> Coins;
    public bool activerTimer = false;
    public float time = 8.0f;


    private void Update()
    {
        if (activerTimer == true)
        {
            time -= Time.deltaTime;
            if (time <= 0.0f)
            {
                SupprimerCoin();
            }
        }
    }
    public void ApparitionCoins()
    {
        activerTimer = true;
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
            Coins.Add(coinClone);
        }
    }

    public void SupprimerCoin()
    {
        foreach (GameObject Coin in Coins)
        {
            Destroy(Coin);
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
