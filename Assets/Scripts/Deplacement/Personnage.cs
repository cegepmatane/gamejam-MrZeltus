using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnage : MonoBehaviour
{
    public LayerMask mask;
    public enum CaseType { Sol, Mur };
    public CaseType typeCase;
    public Grille grilleActuelle;

    private Vector2Int DeplacerVers;

    float horizontalDeplacement = 0f;
    float verticalDeplacement = 0f;

    private void Update()
    {
        
        if (Input.GetButtonDown("Droite"))
        {
            DeplacerVers = new Vector2Int(1, 0);
            SeDeplacer(DeplacerVers);
        }

        if (Input.GetButtonDown("Gauche"))
        {
            DeplacerVers = new Vector2Int(-1, 0);
            SeDeplacer(DeplacerVers);
        }

        if (Input.GetButtonDown("Avancer"))
        {
            DeplacerVers = new Vector2Int(0, 1);
            SeDeplacer(DeplacerVers);
        }

        if (Input.GetButtonDown("Reculer"))
        {
            DeplacerVers = new Vector2Int(0, -1);
            SeDeplacer(DeplacerVers);
        }

    }

    private void SeDeplacer(Vector2Int position)
    {
        if (DeplacementPossible(position))
        {
            DeplacerJoueur(position);
            Debug.Log("Déplacement possible");
        }
        else
        {
            Debug.Log("Déplacement Impossible");
        }
    }

    private bool DeplacementPossible(Vector2Int position)
    {
        Vector2Int positionJoueur = grilleActuelle.WorldToGrid(transform.position);

        foreach (Case tuile in grilleActuelle.TilesList)
        {
            if (tuile.GridPos == positionJoueur + position)
            {
                if(tuile.typeCase.ToString() == "Sol")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        return false;
    }

    private void DeplacerJoueur(Vector2Int position)
    {
        Vector2Int positionTemp = grilleActuelle.WorldToGrid(transform.position) + position;
        Vector3 positionJoueur = grilleActuelle.GridToWorld(positionTemp);
        positionJoueur.z = -0.5f;
        transform.position = positionJoueur;
    }
}
