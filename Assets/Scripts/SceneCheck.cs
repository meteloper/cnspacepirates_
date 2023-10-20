using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCheck : MonoBehaviour
{
    private void Awake()
    {
        if(SettingsManager.Instance == null)
        {
            SceneManager.LoadScene(0);
        }
    }
}
