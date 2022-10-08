using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantRotate : MonoBehaviour
{
    [Range(-250, 250)]
    public float rotateSpeed;
    public bool isLocal;

    public void RotateX()
    {
        if(isLocal)
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime, Space.Self);
        else
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime, Space.World);

    }

    public void RotateY()
    {
        if (isLocal)
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.Self);
        else
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }
    public void RotateZ()
    {
        if (isLocal)
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime, Space.Self);
        else
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime, Space.World);
    }

}
