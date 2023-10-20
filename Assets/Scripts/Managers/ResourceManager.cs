using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CollectResource());
    }


    private IEnumerator CollectResource()
    {
        while (true)
        {

            if (SettingsManager.Instance.LastResourceCollectionTime > 0)
            {
                DateTime.FromOADate(SettingsManager.Instance.LastResourceCollectionTime);
                float secondsPassedSinceLastShutdown = (int)(DateTime.Now - DateTime.FromOADate(SettingsManager.Instance.LastResourceCollectionTime)).TotalSeconds;

                Debug.Log($"{secondsPassedSinceLastShutdown} second was passed.");
                SettingsManager.Instance.Resource1Amount += SettingsManager.Instance.Resource1PerHour / 3600f * secondsPassedSinceLastShutdown;
                SettingsManager.Instance.Resource2Amount += SettingsManager.Instance.Resource2PerHour / 3600f * secondsPassedSinceLastShutdown;
                SettingsManager.Instance.Resource3Amount += SettingsManager.Instance.Resource3PerHour / 3600f * secondsPassedSinceLastShutdown;
                SettingsManager.Instance.Resource4Amount += SettingsManager.Instance.Resource4PerHour / 3600f * secondsPassedSinceLastShutdown;

                SettingsManager.Instance.LastResourceCollectionTime = DateTime.Now.ToOADate();
                SettingsManager.Instance.NotificateResourceChanges();
            }
            else
                SettingsManager.Instance.LastResourceCollectionTime = DateTime.Now.ToOADate();

            SettingsManager.Instance.Save();
            yield return new WaitForSecondsRealtime(1);
        }
    }
}
