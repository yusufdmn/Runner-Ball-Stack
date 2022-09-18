using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    #region Singleton Definiton
    private static CanvasManager instance;       // ******Definition of Singleton********
    public static CanvasManager Instance { get { return instance; } }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion

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
