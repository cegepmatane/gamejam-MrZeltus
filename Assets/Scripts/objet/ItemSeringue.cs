using UnityEngine;

public class ItemSeringue : Item
{
    public override void utiliser()
    {
        base.utiliser();
        Debug.Log("utilisation seringe");
    }
}
