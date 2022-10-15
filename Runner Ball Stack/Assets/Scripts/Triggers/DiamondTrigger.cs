using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RDG;

public class DiamondTrigger : MonoBehaviour
{
    int diamondWorth = 1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FirstBall" || other.tag == "ball")
        {

            Vibration.Vibrate(35);
            
            ScoreManager.Instance.CollectDiamond(diamondWorth);
            Destroy(gameObject);
        }
    }

}
