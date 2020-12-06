using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOver : MonoBehaviour
{
    public void isOverObject()
    {
        PersonnageUtiliser.Instance.isOverUI = true;
    }
    public void isNotOverObject()
    {
        PersonnageUtiliser.Instance.isOverUI = false;

    }
}
