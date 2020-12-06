using UnityEngine;

public class PersonnageRamasser : MonoBehaviour
{
    public GameObject objet;
    public bool playerHit = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && playerHit == true && hit.collider.gameObject == objet)
            {
                Inventaire.Instance.Recuperer(hit.transform.GetComponent<Item>());
            }
        }
    }
}
