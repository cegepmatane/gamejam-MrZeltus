using UnityEngine;

public class ItemPM : Item
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    [SerializeField] private float cadenceDeTir = 0.2f; // cadence de tire, le spred, le monbre de balle, les degas
    [SerializeField] private float spred = 0.2f;
    [SerializeField] private int NbBalle = 1;
    [SerializeField] public int dommage = 5;
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
