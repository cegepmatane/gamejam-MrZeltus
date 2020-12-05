using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiFocus : MonoBehaviour
{
    public static EnnemiFocus Instance;
    public List<Ennemis> ennemis = new List<Ennemis>();

    private void Awake()
    {
        if(Instance != null)
            Debug.Log("Une instance a déjà été créée");
        Instance = this;
    }

    public void FocusJoueur()
    {
        Pathfinder pathfinder = Pathfinder.Instance;
        foreach (Ennemis ennemi in ennemis)
        {
            Vector2Int positionEnnemis = Grille.Instance.WorldToGrid(ennemi.transform.position);
            Vector2Int positionJoueur = Grille.Instance.WorldToGrid(Personnage.Instance.transform.position);
            Case StartTile = TrouverCase(positionEnnemis);
            Case EndTile = TrouverCase(positionJoueur);
            Debug.Log(pathfinder);
            ennemi.GetComponent<Ennemis>().Path = pathfinder.GetPath(StartTile, EndTile, false);
        }
        
    }

    public Case TrouverCase(Vector2Int position)
    {
        foreach (Case tuile in Grille.Instance.TilesList)
        {
            if (tuile.GridPos == position)
            {
                return tuile;
            }
        }
        Debug.LogError("Tuile non trouvée");
        return new Case();
    }
}
