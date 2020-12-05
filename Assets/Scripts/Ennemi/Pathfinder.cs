using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[RequireComponent(typeof(Grille))]
public class Pathfinder : MonoBehaviour
{
    public class Node
    {
        public Case Tile;
        public int f, g, h;
        public Node Parent;
    }

    private Grille m_Grid;
    private Node[,] m_Nodes;

    private void Awake()
    {
        m_Grid = GetComponent<Grille>();
    }
    private void Start()
    {
        m_Nodes = new Node[m_Grid.ColumnCount, m_Grid.RowCount];

        for (int i = 0; i < m_Grid.ColumnCount; i++)
        {
            for (int j = 0; j < m_Grid.RowCount; j++)
            {
                Case t_tile = m_Grid.GetTile(new Vector2Int(i, j));
                if (t_tile == null)
                    continue;
                Node t_Node = new Node();
                t_Node.Tile = t_tile;
                m_Nodes[i, j] = t_Node;
            }
        }
    }

    private void ResetNodes()
    {
        foreach (Node node in m_Nodes)
        {
            node.f = 0;
            node.g = 0;
            node.h = 0;
            node.Parent = null;
        }
    }


    public Path GetPath(Case a_StartTile, Case a_EndTile, bool a_DiagonalAllowed)
    {
        if (a_StartTile == null)
            throw new ExeptionGrille("Start tile is null");
        if (a_EndTile == null)
            throw new ExeptionGrille("End tile is null");

        if (a_StartTile == a_EndTile)
            throw new ExeptionGrille("Start tile is the same as End tile");

        ResetNodes();

        List<Node> t_OpenList = new List<Node>();
        List<Node> t_CloseList = new List<Node>();

        Node t_StartNode = m_Nodes[a_StartTile.GridPos.x, a_StartTile.GridPos.y];
        Node t_EndNode = m_Nodes[a_EndTile.GridPos.x, a_EndTile.GridPos.y];

        Node t_Current = null;

        t_OpenList.Add(t_StartNode);
        while (t_OpenList.Count > 0)
        {
            int t_LowestF = t_OpenList.Min(t => t.f);
            t_Current = t_OpenList.Find(t => t.f == t_LowestF);
            t_OpenList.Remove(t_Current);
            t_CloseList.Add(t_Current);


            if (t_Current == t_EndNode)
                break;

            List<Node> t_Neighbours = GetNeighbours(t_Current);
            foreach (Node t_Neighbour in t_Neighbours)
            {
                if (t_Neighbour.Tile.BaseCost == 0 || t_CloseList.Contains(t_Neighbour))
                    continue;

                int t_NeighbourMultiplier = 10;

                //If diagonal
                if (t_Neighbour.Tile.GridPos.x != t_Current.Tile.GridPos.x && t_Neighbour.Tile.GridPos.y != t_Current.Tile.GridPos.y)
                {
                    if (!a_DiagonalAllowed)
                        continue;
                    t_NeighbourMultiplier = 14;
                }


                int t_NewNeighbourG = t_Current.g + (int)(t_Neighbour.Tile.BaseCost * t_NeighbourMultiplier);



                if (t_NewNeighbourG < t_Neighbour.g || !t_OpenList.Contains(t_Neighbour))
                {
                    t_Neighbour.g = t_NewNeighbourG;
                    t_Neighbour.h = Heuristic(t_Neighbour, t_EndNode);
                    t_Neighbour.f = t_Neighbour.g + t_Neighbour.h;
                    t_Neighbour.Parent = t_Current;
                    if (!t_OpenList.Contains(t_Neighbour))
                        t_OpenList.Add(t_Neighbour);

                }

            }


        }

        if (t_Current != t_EndNode)
            return null;


        List<Case> t_Checkpoints = new List<Case>();
        while (t_Current.Parent != null)
        {
            t_Checkpoints.Add(t_Current.Tile);
            t_Current = t_Current.Parent;
        }
        t_Checkpoints.Add(t_Current.Tile);
        t_Checkpoints.Reverse();


        Path t_Path = new Path();
        t_Path.Checkpoints = t_Checkpoints;

        return t_Path;
    }

    private int Heuristic(Node a_Node, Node a_EndNode)
    {
        int dx = Math.Abs(a_Node.Tile.GridPos.x - a_EndNode.Tile.GridPos.x);
        int dy = Math.Abs(a_Node.Tile.GridPos.y - a_EndNode.Tile.GridPos.y);
        return dx + dy;
    }



    private List<Node> GetNeighbours(Node a_Node)
    {
        List<Node> t_Neighbours = new List<Node>();
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0) continue;

                int x = a_Node.Tile.GridPos.x + i;
                int y = a_Node.Tile.GridPos.y + j;

                if (x < 0) continue;
                if (y < 0) continue;

                if (x >= m_Grid.ColumnCount) continue;
                if (y >= m_Grid.RowCount) continue;

                t_Neighbours.Add(m_Nodes[x, y]);

            }
        }


        return t_Neighbours;
    }
}
