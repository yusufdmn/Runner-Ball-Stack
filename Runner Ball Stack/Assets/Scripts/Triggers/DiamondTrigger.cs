using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondTrigger : MonoBehaviour
{
    int diamondWorth = 10;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FirstBall" || other.tag == "ball")
        {
            ScoreManager.Instance.currentScore += diamondWorth;
            //DiamondData.Instance.AddOrReduceDiamond(diamondWorth);
            Destroy(gameObject);
        }
    }

}
