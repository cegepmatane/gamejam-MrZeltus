using UnityEngine;

public class Recuperation : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PersonnageRamasser>().objet = transform.parent.gameObject;
            collision.transform.GetComponent<PersonnageRamasser>().playerHit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<PersonnageRamasser>().playerHit = false;
        }
    }
}
