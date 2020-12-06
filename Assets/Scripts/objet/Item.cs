using UnityEngine;

public class Item : MonoBehaviour
{
    public SpriteRenderer image;
    public enum ItemType
    {
        Arme,
        Objet,
    }

    public ItemType itemType;

    public virtual void utiliser()
    {
        Debug.Log("ajouter la fonction");
    }
    public virtual void attaquer()
    {

    }
    protected void Tire(int NbBalle, Transform firePoint, float spred, GameObject bulletPrefab, float bulletForce, int dommage)
    {
        GameObject bullet = new GameObject();
        for (int i = 0; i < NbBalle; i++)
        {
            float firepointNx = firePoint.up.x - spred;
            float firepointPx = firePoint.up.x + spred;
            float firepointNy = firePoint.up.y - spred;
            float firepointPy = firePoint.up.y + spred;
            Vector3 rotationx = firePoint.up;
            Vector3 rotationy = firePoint.up;
            float anglex = Random.Range(firepointNx, firepointPx);
            float angley = Random.Range(firepointNy, firepointPy);
            rotationx.x += anglex;
            rotationy.y += angley;
            Vector3 rotation = new Vector3(rotationx.x, rotationy.y, 0.0f);
            bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Bullet>().dommage = dommage;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(rotation * bulletForce, ForceMode2D.Impulse);
        }
    }
}
