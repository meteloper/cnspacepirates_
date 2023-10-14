using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SpacePirates.UI
{
    public enum MainMenuScn
    {
        Headquarters, Hangar, Laboratory, Workshop
    }

    public class PnlMainMenu : MonoBehaviour
    {
        public ScreenHeadQuarters HeadQuarter;
        public ScreenHangar Hangar;
        public ScreenLaboratory Laboratory;
        public ScreenWorkshop Workshop;

        public Button BtnHeadQuarter;
        public Button BtnHangar;
        public Button BtnLaboratory;
        public Button BtnWorkshop;

        public MainMenuScn CurrentScn = MainMenuScn.Headquarters;

        private void Start()
        {
            BtnHangar.onClick.RemoveAllListeners();
            BtnHangar.onClick.AddListener(OnClickBtnHangar);

            BtnHeadQuarter.onClick.RemoveAllListeners();
            BtnHeadQuarter.onClick.AddListener(OnClickBtnHeadQuarter);

            BtnLaboratory.onClick.RemoveAllListeners();
            BtnLaboratory.onClick.AddListener(OnClickBtnLaboratory);

            BtnWorkshop.onClick.RemoveAllListeners();
            BtnWorkshop.onClick.AddListener(OnClickBtnWorkshop);
        }

        private void HideAllScn()
        {
            HeadQuarter.gameObject.SetActive(false);
            Hangar.gameObject.SetActive(false);
            Laboratory.gameObject.SetActive(false);
            Workshop.gameObject.SetActive(false);
        }

        public void ShowPanel(MainMenuScn scn)
        {
            HideAllScn();
            CurrentScn = scn;

            switch (scn)
            {
                case MainMenuScn.Headquarters:
                    HeadQuarter.gameObject.SetActive(true);
                    break;
                case MainMenuScn.Hangar:
                    Hangar.gameObject.SetActive(true);
                    break;
                case MainMenuScn.Laboratory:
                    Laboratory.gameObject.SetActive(true);
                    break;
                case MainMenuScn.Workshop:
                    Workshop.gameObject.SetActive(true);
                    break;

                default:
                    break;
            }
        }

        #region Buttons

        private void OnClickBtnHangar()
        {
            ShowPanel(MainMenuScn.Hangar);
        }
        private void OnClickBtnHeadQuarter()
        {
            ShowPanel(MainMenuScn.Headquarters);
        }

        private void OnClickBtnLaboratory()
        {
            ShowPanel(MainMenuScn.Laboratory);
        }

        private void OnClickBtnWorkshop()
        {
            ShowPanel(MainMenuScn.Workshop);
        }

        #endregion




    }



}
