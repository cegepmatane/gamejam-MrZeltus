using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Grille))]
[CanEditMultipleObjects]
public class GridEditor : Editor
{
    private void OnSceneGUI()
    {
        if (Event.current.type == EventType.MouseDown && Event.current.control)
        {
            //Debug.Log("Control +click");

            GUIUtility.hotControl = GUIUtility.GetControlID(FocusType.Passive);



            Vector3 t_ClickPose = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition).origin;
            Vector2Int t_GridPos = ((Grille)target).WorldToGrid(t_ClickPose);

            Vector3 t_WorldPos = ((Grille)target).GridToWorld(t_GridPos);

            int t_SelectedTile = ((Grille)target).SelectedTile;

            if (t_SelectedTile >= ((Grille)target).AvailibleTime.Length || t_SelectedTile < 0)
                throw new ExeptionGrille("Selected tile out of bounds");


            //Suprimer anciene Tuile 
            List<Case> t_Tiles = ((Grille)target).GetComponentsInChildren<Case>().ToList();
            Case t_OldTile = t_Tiles.FirstOrDefault(t => t.transform.position == t_WorldPos);
            if (t_OldTile)
            {
                Undo.DestroyObjectImmediate(t_OldTile.gameObject);
            }
            //Trouver la reference de la prefab a instantier
            GameObject t_TilePrefab = ((Grille)target).AvailibleTime[t_SelectedTile];


            //Instatier la tuile et la parenter
            GameObject t_NewTileGo = (GameObject)PrefabUtility.InstantiatePrefab(t_TilePrefab, ((Grille)target).transform);
            Undo.RegisterCreatedObjectUndo(t_NewTileGo, "Tile created");
            t_NewTileGo.transform.position = t_WorldPos;

            //Position
            float t_CellSize = ((Grille)target).CellSize;
            Sprite t_Sprite = t_NewTileGo.GetComponent<SpriteRenderer>().sprite;
            float t_Scale = t_CellSize / t_Sprite.bounds.size.x;
            t_NewTileGo.transform.localScale = new Vector3(t_Scale, t_Scale, t_Scale);
            t_NewTileGo.GetComponent<Case>().GridPos = t_GridPos;




        }
    }


}
