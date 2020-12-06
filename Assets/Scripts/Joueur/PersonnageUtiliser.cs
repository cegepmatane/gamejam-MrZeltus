using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PersonnageUtiliser : MonoBehaviour
{
    public static PersonnageUtiliser Instance;
    public bool isOverUI = false;

    public void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isOverUI == false)
        {
                Inventaire.Instance.UtiliserItem();
        }
        if (Input.GetMouseButton(0) && isOverUI == false)
        {
                Inventaire.Instance.UtiliserArme();
        }
    }
}
