using UnityEngine;

public class PersonnageRamasser : MonoBehaviour
{
    Inventaire inventaire;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                Inventaire.Instance.Recuperer(hit.transform.GetComponent<Item>());
            }
        }
    }
}
