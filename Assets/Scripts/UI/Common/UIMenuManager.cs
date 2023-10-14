using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpacePirates.UI
{
    public enum Panels
    {
        Login, MainMenu
    }

    public class UIMenuManager : MonoBehaviour
    {
        public PnlLogin Login;
        public PnlMainMenu MainMenu;


        public Panels currentPanel = Panels.Login;

        private void Start()
        {
            HideAllPanel();
            InitLogin();

            ShowPanel(Panels.Login);
        }

        private void HideAllPanel()
        {
            Login.gameObject.SetActive(false);
            MainMenu.gameObject.SetActive(false);
        }

        public void ShowPanel(Panels panel)
        {
            HideAllPanel();

            Debug.Log($"{panel.ToString()} was opened!");

            switch (panel)
            {
                case Panels.Login:
                    Login.gameObject.SetActive(true);
                    break;
                case Panels.MainMenu:
                    MainMenu.gameObject.SetActive(true);
                    break;
          
                default:
                    break;
            }
        }



        private void InitLogin()
        {
            void OnClickBtnPlayAsGuest()
            {
                ShowPanel(Panels.MainMenu);
            }

            Login.BtnPlayAsGuest.onClick.RemoveAllListeners();
            Login.BtnPlayAsGuest.onClick.AddListener(OnClickBtnPlayAsGuest);
        }
    }

}
