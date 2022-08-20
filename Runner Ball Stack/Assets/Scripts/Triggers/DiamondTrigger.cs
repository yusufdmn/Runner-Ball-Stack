using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondTrigger : MonoBehaviour
{
    int addedDiamond = 10;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "FirstBall" || other.tag == "ball")
        {
            DiamondData.Instance.AddOrReduceDiamond(addedDiamond);
            Destroy(gameObject);
        }
    }

}
