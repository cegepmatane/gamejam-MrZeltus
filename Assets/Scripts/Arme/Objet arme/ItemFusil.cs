using UnityEngine;

public class ItemFusil : Item
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 40f;

    [SerializeField] private float cadenceDeTir = 1.3f; // cadence de tire, le spred, le monbre de balle, les degas
    [SerializeField] private float spred = 0.01f;
    [SerializeField] private int NbBalle = 1;
    [SerializeField] public int dommage = 50;
    private float lastShot;

    public void Start()
    {
        firePoint = Personnage.Instance.firePoint;
    }
    public override void attaquer()
    {
        float time = Time.time;
        if (time - lastShot >= cadenceDeTir)
        {
            lastShot = time;
            if (Input.GetButton("Fire1"))
            {
                Tire(NbBalle, firePoint, spred, bulletPrefab, bulletForce, dommage);
            }
        }
    }
}
