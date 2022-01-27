using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFurniture : MonoBehaviour
{
    public GameObject furniture;
    public float rotationSpeed = 30;
    bool rotate = false;

    void Update()
    {
        if (rotate == false)
            return;

        furniture.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

    public void rotationON()
    {
        rotate = true;
    }
    public void rotationOFF()
    {
        rotate = false;
    }

}
