using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
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
        mainMenu.SetActive(false);
    }
    public void DisplayFailPanel()
    {
        failPanel.SetActive(true);
        mainMenu.SetActive(false);
    }
}