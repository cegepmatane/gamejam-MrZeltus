using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject imageShield;
    public GameObject imageSpeed;

    // Update is called once per frame
    void Update()
    {
        imageShield.SetActive(Personnage.Instance.isShield);
        imageSpeed.SetActive(Personnage.Instance.isSpeed);
    }
}
