using UnityEngine;
using UnityEngine.EventSystems;

public class PersonnageUtiliser : MonoBehaviour
{
    private  void Update()
    {
        if (Input.GetMouseButtonDown(1) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider == null)
            {
                Inventaire.Instance.UtiliserItem();
            }
        }
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider == null)
            {
                Inventaire.Instance.UtiliserArme();
            }
        }
    }
}
