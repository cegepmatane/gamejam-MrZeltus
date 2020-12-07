using UnityEngine;

public class ItemSuperBullet : Item
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    [SerializeField] private float cadenceDeTir = 0.4f; // cadence de tire, le spred, le monbre de balle, les degas
    [SerializeField] private float spred = 0.5f;
    [SerializeField] private int NbBalle = 4;
    [SerializeField] public int dommage = 10;
    private float lastShot;

    public void Start()
    {
        firePoint = Personnage.Instance.firePoint;
    }

    public override void utiliser()
    {
        base.utiliser();
        float time = Time.time;
        if (time - lastShot >= cadenceDeTir)
        {
            lastShot = time;
            Tire(NbBalle, firePoint, spred, bulletPrefab, bulletForce, dommage);
        }
    }
}
