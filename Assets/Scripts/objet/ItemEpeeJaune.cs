using UnityEngine;

public class ItemEpeeJaune : Item
{
    public override void attaquer()
    {
        base.attaquer();
        Debug.Log("attaque avec epeeJaune");
    }
}
