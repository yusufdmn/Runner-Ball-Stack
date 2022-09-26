using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEndTrigger: MonoBehaviour
{
    [SerializeField] CircleEnd circleEnd;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball" || other.tag == "FirstBall")
        {
            other.tag = "PassedLine";
            if (!circleEnd.areCirclesFull)
                StartCoroutine(circleEnd.FlyNextBallToCircle());
            else
                StartCoroutine(circleEnd.FlyNextBallToLastSpot());
            circleEnd.areCirclesFull = circleEnd.CheckIfCirclesFull();

        }
    }
}
