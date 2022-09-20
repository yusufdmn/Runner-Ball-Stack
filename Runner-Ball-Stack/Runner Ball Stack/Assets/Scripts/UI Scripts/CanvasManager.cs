using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject hidedMenu;
    [SerializeField] GameObject endPanel;
    [SerializeField] GameObject failPanel;

    public void HideMainMenu()
    {
        hidedMenu.SetActive(false);
    }
    public void DisplayEndPanel()
    {
        endPanel.SetActive(true);
    }
    public void DisplayFailPanel()
    {
        failPanel.SetActive(true);
    }
}