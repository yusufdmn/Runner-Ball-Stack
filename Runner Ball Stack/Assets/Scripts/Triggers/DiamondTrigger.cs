using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondTrigger : MonoBehaviour
{
    int diamondWorth = 5;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FirstBall" || other.tag == "ball")
        {
            Handheld.Vibrate();

            ScoreManager.Instance.CollectDiamond(diamondWorth);
            //DiamondData.Instance.AddOrReduceDiamond(diamondWorth);
            Destroy(gameObject);
        }
    }

}
