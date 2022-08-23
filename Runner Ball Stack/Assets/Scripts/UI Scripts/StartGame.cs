using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public FirstBallMoveForward firstBallMoveForward;
    public List<GameObject> hidedUIObjects;

    public void StartTheGame()
    {
        foreach(GameObject uýObj in hidedUIObjects)
        {
            uýObj.SetActive(false);
        }

        firstBallMoveForward.enabled = true;
    }
}
