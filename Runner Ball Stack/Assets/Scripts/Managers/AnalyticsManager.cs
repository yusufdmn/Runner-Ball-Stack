using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;
using Unity.Services.Core;

public class AnalyticsManager : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    async void Start()
    {
        try
        {
            await UnityServices.InitializeAsync();
            List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
        }
        catch (ConsentCheckException e)
        {
            // Something went wrong when checking the GeoIP, check the e.Reason and handle appropriately.
        }
        
    }


    public void SendEventMessage(string key)
    {
        
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            {"userLevel", levelManager.level}
        };
        AnalyticsService.Instance.CustomData(key, parameters);
        AnalyticsService.Instance.Flush();
    }

}
