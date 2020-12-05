using UnityEngine;
using UnityEngine.EventSystems;

public class PersonnageUtiliser : MonoBehaviour
{
    private  void Update()
    {
        if (Input.GetMouseButtonDown(1) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            Inventaire.Instance.UtiliserItem();
        }
    }
}
