using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpacePirates.Test
{
    public class TestUIStandard : MonoBehaviour
    {
        public UIStandard uiStandart;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                uiStandart.Info("Good job!", "Information", "OK",
                    () => {
                        Debug.Log("Info popup was closed.");
                    });
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                uiStandart.Error("Oppss Very bad!", "Error", "CLOSE",
                    () => {
                        Debug.Log("Error popup was closed.");
                    });
            }


            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                uiStandart.Confirm( "Are you sure?", "Question", "YES", "NO", 
                    () => {
                        Debug.Log("Answer is YES");
                    },
                    () => {
                        Debug.Log("Answer is NO");
                    });
            }


            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                uiStandart.Prompt("Enter your name.", "Username", "Enter", "",
                 (value) => {
                     Debug.Log($"Nice to met you {value}.");
                 });
            }
        }
    }
}


