using CodeStage.AntiCheat.ObscuredTypes;
using CodeStage.AntiCheat.Storage;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public ObscuredInt Resource1PerHour = 6000;
    public ObscuredInt Resource2PerHour = 2000;
    public ObscuredInt Resource3PerHour = 500;
    public ObscuredInt Resource4PerHour = 100;

    public ObscuredInt Resource1Amount = 600;
    public ObscuredInt Resource2Amount = 200;
    public ObscuredInt Resource3Amount = 50;
    public ObscuredInt Resource4Amount = 10;

    public ObscuredDouble LastResourceCollectionTime = double.MinValue;

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
        ObscuredPrefs.Set(nameof(Resource1PerHour), Resource1PerHour);
        ObscuredPrefs.Set(nameof(Resource2PerHour), Resource2PerHour);
        ObscuredPrefs.Set(nameof(Resource3PerHour), Resource3PerHour);
        ObscuredPrefs.Set(nameof(Resource4PerHour), Resource4PerHour);

        ObscuredPrefs.Set(nameof(Resource1Amount), Resource1Amount);
        ObscuredPrefs.Set(nameof(Resource2Amount), Resource2Amount);
        ObscuredPrefs.Set(nameof(Resource3Amount), Resource3Amount);
        ObscuredPrefs.Set(nameof(Resource4Amount), Resource4Amount);

        ObscuredPrefs.Set(nameof(LastResourceCollectionTime), LastResourceCollectionTime);
    }

    public void Load()
    {
        Resource1PerHour = ObscuredPrefs.Get(nameof(Resource1PerHour), Resource1PerHour);
        Resource2PerHour = ObscuredPrefs.Get(nameof(Resource2PerHour), Resource2PerHour);
        Resource3PerHour = ObscuredPrefs.Get(nameof(Resource3PerHour), Resource3PerHour);
        Resource4PerHour = ObscuredPrefs.Get(nameof(Resource4PerHour), Resource4PerHour);

        Resource1Amount = ObscuredPrefs.Get(nameof(Resource1Amount), Resource1Amount);
        Resource2Amount = ObscuredPrefs.Get(nameof(Resource2Amount), Resource2Amount);
        Resource3Amount = ObscuredPrefs.Get(nameof(Resource3Amount), Resource3Amount);
        Resource4Amount = ObscuredPrefs.Get(nameof(Resource4Amount), Resource4Amount);

        LastResourceCollectionTime = ObscuredPrefs.Get(nameof(LastResourceCollectionTime), LastResourceCollectionTime);
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
