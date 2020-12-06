using UnityEngine;

public class PersonnageRamasser : MonoBehaviour
{
    public GameObject objet;
    public bool playerHit = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("salut");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 9);
            Debug.Log(hit.collider != null);
            Debug.Log(playerHit == true);
            Debug.Log(hit.collider.tag == "Objet");
            Debug.Log(hit.collider.gameObject == objet);
            if (hit.collider != null && playerHit == true && hit.collider.tag == "Objet" && hit.collider.gameObject == objet)
            {
                Debug.Log("salut222");
                Inventaire.Instance.Recuperer(hit.transform.GetComponent<Item>());
            }
        }
    }
}
