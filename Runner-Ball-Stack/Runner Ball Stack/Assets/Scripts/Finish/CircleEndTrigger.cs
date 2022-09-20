using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEndTrigger : MonoBehaviour
{
    [SerializeField] CircleEnd circleEnd;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ball" || other.tag == "FirstBall")
        {

            other.tag = "Untagged";
            Debug.Log(1);
            circleEnd.FlyNextBallToCircle();
        }
    }

}