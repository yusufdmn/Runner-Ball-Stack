using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public FirstBallMoveForward firstBallMoveForward;
    public List<GameObject> hidedUIObjects;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void StartTheGame()
    {
        foreach(GameObject u�Obj in hidedUIObjects)
        {
            u�Obj.SetActive(false);
        }

        firstBallMoveForward.enabled = true;
    }
}
