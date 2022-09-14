using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdWheelArrow : MonoBehaviour
{
    [SerializeField] float rotateSpeed;
    [SerializeField] float maxAngle;
    Quaternion rotateVectorMax;
    Quaternion rotateVectorMin;
    float a = 0;
    int rotateDirection = 1;
 
    private void Start()
    {
        rotateVectorMax = Quaternion.Euler(0, 0, maxAngle);
        rotateVectorMin = Quaternion.Euler(0, 0, -maxAngle);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(rotateVectorMin, rotateVectorMax, a * rotateSpeed);

        a += Time.deltaTime * rotateDirection;
        if (a * rotateSpeed > 0.99)
            rotateDirection = -1;
        else if (a * rotateSpeed < 0.01)
            rotateDirection = 1;
    }

}
