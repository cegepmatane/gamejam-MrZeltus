using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Grille : MonoBehaviour
{
    public int RowCount, ColumnCount;
    public float CellSize = 1f;
    public Color GridColor;
    public bool ShowGrid = true;
    public Case[] TilesList;
    public Case[,] m_TilesList;
    [Space(2)]
    [Header("Grid Editor")]
#if UNITY_EDITOR
    public GameObject[] AvailibleTime;
    public int SelectedTile;
#endif

    public void Awake()
    {

        TilesList = gameObject.GetComponentsInChildren<Case>();
        m_TilesList = new Case[ColumnCount, RowCount];
        foreach (Case tile in TilesList)
        {
            Vector2Int t_tilePos = WorldToGrid(tile.transform.position);
            tile.GridPos = t_tilePos;
            m_TilesList[t_tilePos.x, t_tilePos.y] = tile;
        }   
    }




    private void OnDrawGizmosSelected()
    {
        if (!ShowGrid)
            return;
        float t_StartX = transform.position.x;
        float t_EndX = ColumnCount * CellSize + transform.position.x;

        float t_StartY = transform.position.y;
        float t_EndY = RowCount * CellSize + transform.position.y;

        Gizmos.color = GridColor;

        for (int i = 0; i < RowCount + 1; i++)
        {
            float t_LineY = i * CellSize + transform.position.y;
            Gizmos.DrawLine(new Vector3(t_StartX, t_LineY, 0), new Vector3(t_EndX, t_LineY, 0));
        }
        for (int j = 0; j < ColumnCount + 1; j++)
        {
            float t_LineX = j * CellSize + transform.position.x;
            Gizmos.DrawLine(new Vector3(t_LineX, t_StartY, 0), new Vector3(t_LineX, t_EndY, 0));
        }
    }
    public Vector2Int WorldToGrid(Vector3 a_WorldPos)
    {
        int t_PosX = Mathf.FloorToInt((a_WorldPos.x - transform.position.x) / CellSize);
        int t_PosY = Mathf.FloorToInt((a_WorldPos.y - transform.position.y) / CellSize);

        //Exeption
        if (t_PosX < 0 || t_PosX >= ColumnCount || t_PosY < 0 || t_PosY >= RowCount)
            throw new ExeptionGrille("Out of Grid");


        return new Vector2Int(t_PosX, t_PosY);
    }


    public Case GetTile(Vector2Int a_GridPos)
    {
        if (a_GridPos.x < 0 || a_GridPos.x >= ColumnCount || a_GridPos.y < 0 || a_GridPos.y >= RowCount)
            throw new ExeptionGrille("Out of Grid");
        return m_TilesList[a_GridPos.x, a_GridPos.y];
    }
    public void replaceTile(GameObject replaceTile,Vector2Int position)
    {
        Case toReplace = GetTile(position);
        Destroy(toReplace.gameObject);

        GameObject t_NewTileGo = Instantiate(replaceTile,GridToWorld(position),Quaternion.identity);
       
        //Position
        float t_CellSize = CellSize;
        Sprite t_Sprite = t_NewTileGo.GetComponent<SpriteRenderer>().sprite;
        float t_Scale = t_CellSize / t_Sprite.bounds.size.x;
        t_NewTileGo.transform.localScale = new Vector3(t_Scale, t_Scale, t_Scale);
        t_NewTileGo.GetComponent<Case>().GridPos = position;
    }

    public Vector3 GridToWorld(Vector2Int a_GridPos)
    {
        //Exeption
        if (a_GridPos.x < 0 || a_GridPos.x >= ColumnCount || a_GridPos.y < 0 || a_GridPos.y >= RowCount)
            throw new ExeptionGrille("Out of Grid");

        float t_PosX = a_GridPos.x * CellSize + (CellSize / 2) + transform.position.x;
        float t_PosY = a_GridPos.y * CellSize + (CellSize / 2) + transform.position.y;

        return new Vector2(t_PosX, t_PosY);


    }


}
