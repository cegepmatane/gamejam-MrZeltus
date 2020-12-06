using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject image;
    // Update is called once per frame
    void Update()
    {
        Vector3 pz = Input.mousePosition;
        image.transform.position = pz;
    }
}
