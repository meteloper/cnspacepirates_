using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;
using UnityEngine.UI;

namespace SpacePirates.UI
{
    public enum MainMenuScn
    {
        Home = -1, Headquarters = 0, Hangar = 1, Laboratory = 2, Workshop = 3
    }

    public class PnlMainMenu : MonoBehaviour
    {
        public TextMeshProUGUI TxtSceneName;
        public Button BtnCloseScene;
        public RectTransform RectPanelScene;
        public LocalizedStringTable LocalizedTable;
        public StringTable currentLocalizeTable;

        public Button BtnHeadQuarter;
        public Button BtnHangar;
        public Button BtnLaboratory;
        public Button BtnWorkshop;

        public TextMeshProUGUI TxtResource1Amount;
        public TextMeshProUGUI TxtResource2Amount;
        public TextMeshProUGUI TxtResource3Amount;
        public TextMeshProUGUI TxtResource4Amount;



        public MainMenuScn CurrentScn = MainMenuScn.Headquarters;

        private string[] localizedKeys = new string[] {"btnHQ","btnHangar","btnLab","btnWorkshop"};

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

            BtnCloseScene.onClick.RemoveAllListeners();
            BtnCloseScene.onClick.AddListener(OnClickBtnCloseScene);

            currentLocalizeTable = LocalizedTable.GetTable();

            SettingsManager.Instance.ActionOnResourcesChanged += OnResourcesChanged;
            OnResourcesChanged();
        }

        private void OnResourcesChanged()
        {
            TxtResource1Amount.text = ((int)SettingsManager.Instance.Resource1Amount).ToString("n0");
            TxtResource2Amount.text = ((int)SettingsManager.Instance.Resource2Amount).ToString("n0");
            TxtResource3Amount.text = ((int)SettingsManager.Instance.Resource3Amount).ToString("n0");
            TxtResource4Amount.text = ((int)SettingsManager.Instance.Resource4Amount).ToString("n0");
        }

        private void OnDestroy()
        {
            if (SettingsManager.Instance != null)
                SettingsManager.Instance.ActionOnResourcesChanged -= OnResourcesChanged;
        }

        private void CloseScene()
        {
            RectPanelScene.DOAnchorPosX(Screen.width, 0.3f).OnComplete(
                () => 
                { 
                    RectPanelScene.gameObject.SetActive(false); 
                });
            CurrentScn = MainMenuScn.Home;
        }

        public void ShowScene(MainMenuScn scn)
        {
            if (CurrentScn == scn)
                return;

            CurrentScn = scn;
            RectPanelScene.anchoredPosition = new Vector2(Screen.width,0);
            RectPanelScene.gameObject.SetActive(true);
            RectPanelScene.DOAnchorPosX(0, 0.3f);
            TxtSceneName.text = currentLocalizeTable.GetEntry(localizedKeys[(int)scn]).Value;
        }

        #region Buttons

        private void OnClickBtnHangar()
        {
            ShowScene(MainMenuScn.Hangar);
        }
        private void OnClickBtnHeadQuarter()
        {
            ShowScene(MainMenuScn.Headquarters);
        }

        private void OnClickBtnLaboratory()
        {
            ShowScene(MainMenuScn.Laboratory);
        }

        private void OnClickBtnWorkshop()
        {
            ShowScene(MainMenuScn.Workshop);
        }

        private void OnClickBtnCloseScene()
        {
            CloseScene();
        }

        #endregion




    }



}
