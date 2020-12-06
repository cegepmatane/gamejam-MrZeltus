using UnityEngine;

public class JetterObjet : MonoBehaviour
{
    public static JetterObjet Instance;

    float speed = 200;
    public void Awake()
    {
        Instance = this;
    }

    public void LancerObjet(Item item, Vector3 position)
    {
        position.z = 0;
        item.transform.position = position;
        item.GetComponent<Rigidbody2D>().AddRelativeForce(Random.onUnitSphere * speed);
    }
}
