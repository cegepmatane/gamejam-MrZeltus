using UnityEngine;

public class ItemSeringeSpeed : Item
{
    public override void utiliser()
    {
        base.utiliser();
        Personnage.Instance.Speed();
    }
}
