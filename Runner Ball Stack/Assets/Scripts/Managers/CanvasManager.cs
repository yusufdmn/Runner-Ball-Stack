using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [Header("Canvas & Menu")]
    [SerializeField] Canvas mainMenu;
    [SerializeField] GameObject hidedMenu;
    [SerializeField] Canvas endPanel;
    [SerializeField] Canvas failPanel;
    [SerializeField] GameObject extraIncomePanel;
    [SerializeField] Canvas unlockObstaclePanel;
    [SerializeField] GameObject settingsPopUp;
    
    [Space(2)]
    [Header("Animation Players")]
    [SerializeField] PlayUIAnimations animPlayerEndCanvas;
    [SerializeField] PlayUIAnimations animPlayerObstacleCanvas;
    [SerializeField] PlayUIAnimations animPlayerFailCanvas;

    public void HideMainMenu()
    {
        hidedMenu.SetActive(false);
    }

    public void DisplayEndPanel()
    {
        StartCoroutine(DisableExtraPanel());
        endPanel.enabled = true;
        mainMenu.enabled = false;

        animPlayerEndCanvas.PlayAnimations();
    }

    public void DisplayFailPanel()
    {
        failPanel.enabled = true;
        mainMenu.enabled = false;

        animPlayerFailCanvas.PlayAnimations();
    }

    IEnumerator DisableExtraPanel()
    {
        yield return new WaitForSeconds(1.5f);
        extraIncomePanel.SetActive(false);
    }

    public void DisplayUnlockObstaclePanel()
    {
        unlockObstaclePanel.enabled = true;
        animPlayerObstacleCanvas.PlayAnimations();
    }

    public void DisplaySettingsPopUp()
    {
        settingsPopUp.SetActive(!settingsPopUp.activeSelf);
    }

}
