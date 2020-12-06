using UnityEngine;

public class ItemCreditCard : Item
{
    public override void utiliser()
    {
        base.utiliser();
        Debug.Log("utilisation Credit Card");
    }
}