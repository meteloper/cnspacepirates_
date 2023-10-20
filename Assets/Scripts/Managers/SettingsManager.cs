using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public Action ActionOnResourcesChanged;

    public ObscuredDouble Resource1PerHour = 6000;
    public ObscuredDouble Resource2PerHour = 2000;
    public ObscuredDouble Resource3PerHour = 500;
    public ObscuredDouble Resource4PerHour = 100;

    public ObscuredDouble Resource1Amount = 600;
    public ObscuredDouble Resource2Amount = 200;
    public ObscuredDouble Resource3Amount = 50;
    public ObscuredDouble Resource4Amount = 10;

    public ObscuredDouble LastResourceCollectionTime = 0;

    public static SettingsManager Instance;

    private void Awake()
    {  
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Load();
    }

    public void Save()
    {
        ObscuredPrefs.Set(nameof(Resource1PerHour), (double)Resource1PerHour);
        ObscuredPrefs.Set(nameof(Resource2PerHour), (double)Resource2PerHour);
        ObscuredPrefs.Set(nameof(Resource3PerHour), (double)Resource3PerHour);
        ObscuredPrefs.Set(nameof(Resource4PerHour), (double)Resource4PerHour);

        ObscuredPrefs.Set(nameof(Resource1Amount), (double)Resource1Amount);
        ObscuredPrefs.Set(nameof(Resource2Amount), (double)Resource2Amount);
        ObscuredPrefs.Set(nameof(Resource3Amount), (double)Resource3Amount);
        ObscuredPrefs.Set(nameof(Resource4Amount), (double)Resource4Amount);
        ObscuredPrefs.Set(nameof(LastResourceCollectionTime), (double)LastResourceCollectionTime);
    }

    public void Load()
    {
        Resource1PerHour = ObscuredPrefs.Get(nameof(Resource1PerHour), (double)Resource1PerHour);
        Resource2PerHour = ObscuredPrefs.Get(nameof(Resource2PerHour), (double)Resource2PerHour);
        Resource3PerHour = ObscuredPrefs.Get(nameof(Resource3PerHour), (double)Resource3PerHour);
        Resource4PerHour = ObscuredPrefs.Get(nameof(Resource4PerHour), (double)Resource4PerHour);

        Resource1Amount = ObscuredPrefs.Get(nameof(Resource1Amount), (double)Resource1Amount);
        Resource2Amount = ObscuredPrefs.Get(nameof(Resource2Amount), (double)Resource2Amount);
        Resource3Amount = ObscuredPrefs.Get(nameof(Resource3Amount), (double)Resource3Amount);
        Resource4Amount = ObscuredPrefs.Get(nameof(Resource4Amount), (double)Resource4Amount);

        LastResourceCollectionTime = ObscuredPrefs.Get(nameof(LastResourceCollectionTime), 0.0);
    }

    public void NotificateResourceChanges()
    {
        ActionOnResourcesChanged?.Invoke();
    }


#if UNITY_EDITOR

    [UnityEditor.MenuItem("Meteloper/Settings/Delete All")]
    public static void DeletePref()
    {
        ObscuredPrefs.DeleteAll();
    }

    [UnityEditor.MenuItem("Meteloper/Settings/Save")]
    public static void SavePref()
    {
        ObscuredPrefs.DeleteAll();
    }


#endif

}
