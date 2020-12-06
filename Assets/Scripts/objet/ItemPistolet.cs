using UnityEngine;

public class ItemPistolet : Item
{
    public override void attaquer()
    {
        base.attaquer();
        Debug.Log("Pistolet");
    }
}
