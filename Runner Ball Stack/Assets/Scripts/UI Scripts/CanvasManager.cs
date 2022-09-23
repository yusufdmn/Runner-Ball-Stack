using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject hidedMenu;
    [SerializeField] GameObject endPanel;
    [SerializeField] GameObject failPanel;
    [SerializeField] GameObject extraIncomePanel;
    public void HideMainMenu()
    {
        hidedMenu.SetActive(false);
    }
    public void DisplayEndPanel()
    {
        StartCoroutine(DisableExtraPanel());
        endPanel.SetActive(true);
        mainMenu.SetActive(false);
    }
    public void DisplayFailPanel()
    {
        failPanel.SetActive(true);
        mainMenu.SetActive(false);
    }

    IEnumerator DisableExtraPanel()
    {
        yield return new WaitForSeconds(1.5f);
        extraIncomePanel.SetActive(false);
    }
}