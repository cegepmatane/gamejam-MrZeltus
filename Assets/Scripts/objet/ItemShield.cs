using UnityEngine;

public class ItemShield : Item
{
    public override void attaquer()
    {
        base.attaquer();
        Debug.Log("Shied");
    }
}
