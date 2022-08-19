using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotate : MonoBehaviour
{
    [Range(1, 150)]
    [SerializeField] float rotateSpeed;

    public void RotateX()
    {
        transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
    }
    public void RotateY()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
    public void RotateZ()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }

}
