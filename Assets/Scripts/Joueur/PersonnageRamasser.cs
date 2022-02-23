using UnityEngine;

public class PersonnageRamasser : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100);
            
            if (hit.collider != null && hit.collider.tag == "Objet")
            {
                Vector3 ecart = hit.collider.gameObject.transform.position - transform.position;
                if (ecart.magnitude <= 1)
                {
                    Inventaire.Instance.Recuperer(hit.transform.GetComponent<Item>());
                }

            }
        }
    }
}
