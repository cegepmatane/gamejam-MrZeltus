using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    public Vector2Int GridPos;
    public enum CaseType {Sol,Mur,Portaille};
    public CaseType typeCase;

    public float BaseCost;

}
