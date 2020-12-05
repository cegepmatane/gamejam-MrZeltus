/* Joseph Breslin 2018
* Rigidbody and transform movement script for 2D player */

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Personnage : MonoBehaviour
{
    public Rigidbody2D body;
    public Camera cam;

    Vector2 movement;
    Vector2 mousePos;

    public float runSpeed = 10.0f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + movement * runSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - body.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        body.rotation = angle;
    }
}