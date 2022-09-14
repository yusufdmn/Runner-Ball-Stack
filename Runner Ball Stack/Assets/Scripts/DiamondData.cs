using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondData : MonoBehaviour
{
    #region Singleton Definiton
    private static DiamondData instance;       // ******Definition of Singleton********
    public static DiamondData Instance { get { return instance; } }
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

    public int diamond;
    [SerializeField] DiamondTextUpdater diamondTextUpdater;

    void Start()
    {
        diamond = PlayerPrefs.GetInt("diamond");
    }

    public void SaveDiamonds(int levelScore)
    {
        diamond += levelScore;
        PlayerPrefs.SetInt("diamond", diamond);
    }
}