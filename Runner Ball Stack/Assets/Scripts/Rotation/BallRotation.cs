using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{

  //  List<RotateInAxisX> rotationScripts;


    public void StartRotation()
    {
        foreach (GameObject ball in StackManager.Instance.stackedBalls)
        {
            ball.GetComponent<RotateInAxisX>().rotateSpeed = 230;
        }
    }




}
