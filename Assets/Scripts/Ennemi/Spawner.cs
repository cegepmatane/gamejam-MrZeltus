using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public float SpawnInterval;
    public Pathfinder Pathfinder;
    public Case StartTile;
    public Case EndTile;
    public bool DiagonalAllowed;

    private float m_LastSpawnTime;

   /*[SerializeField]
    private AudioClip m_StartSound;

    private void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(m_StartSound);
    }*/

    private void Update()
    {
        if (Time.time - m_LastSpawnTime >= SpawnInterval)
        {
            m_LastSpawnTime = Time.time;
            GameObject t_Enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            Vector2Int positionEnnemis = Grille.Instance.WorldToGrid(t_Enemy.transform.position);
            Vector2Int positionJoueur = Grille.Instance.WorldToGrid(Personnage.Instance.transform.position);
            StartTile = TrouverCase(positionEnnemis);
            EndTile = TrouverCase(positionJoueur);
            t_Enemy.GetComponent<Ennemis>().Path = Pathfinder.GetPath(StartTile, EndTile, DiagonalAllowed);
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
