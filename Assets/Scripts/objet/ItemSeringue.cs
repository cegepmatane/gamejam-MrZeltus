using UnityEngine;

public class ItemSeringue : Item
{
    public int healAmmount = 10;
    public override void utiliser()
    {
        base.utiliser();
        Personnage.Instance.Heal(healAmmount);
    }
}
