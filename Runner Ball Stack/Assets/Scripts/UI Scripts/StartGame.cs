using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartGame : MonoBehaviour
{
    public void StartTheGame()
    {
        GameManager.Instance.StartTheGame();
    }

}
