using DG.Tweening;
using SpacePirates.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

namespace SpacePirates
{
    public class UIStandard : MonoBehaviour
    {
        public GameObject UIBackground;
        public UIPopupInfo UIInfo;
        public UIPopupError UIError;
        public UIPopupConfirm UIConfirm;
        public UIPopupPrompt UIPrompt;

        private float fadeDuration = 0.3f;

        private void Start()
        {
            UIBackground.SetActive(false);
        }

        public void Info(string message, string title = "INFORMATION", string buttonCaption = "OK", Action onOK = null)
        {
            DisplayBackground();
            UIInfo.gameObject.SetActive(true);
            UIInfo.TextTitle.text = title;
            UIInfo.TextMessage.text = message;
            UIInfo.TextButtonCaption.text = buttonCaption;
            UIInfo.ButtonOK.onClick.RemoveAllListeners();
            UIInfo.ButtonOK.onClick.AddListener(() => { CloseElements(onOK); });
        }

        public void Error(string message, string title = "ERROR", string buttonCaption = "OK", Action onOK = null)
        {
            DisplayBackground();
            UIError.gameObject.SetActive(true);
            UIError.TextTitle.text = title;
            UIError.TextMessage.text = message;
            UIError.TextButtonCaption.text = buttonCaption;
            UIError.ButtonOK.onClick.RemoveAllListeners();
            UIError.ButtonOK.onClick.AddListener(() => { CloseElements(onOK); });
        }

        public void Confirm(string question, string title = "CONFIRM", string buttonYesCaption = "YES", string buttonNoCaption = "NO", Action onYes = null, Action onNo = null)
        {
            DisplayBackground();
            UIConfirm.gameObject.SetActive(true);
            UIConfirm.TextQuestion.text = question;
            UIConfirm.TextTitle.text = title;
            UIConfirm.TextButtonYesCaption.text = buttonYesCaption;
            UIConfirm.TextButtonNoCaption.text = buttonNoCaption;
            UIConfirm.ButtonYes.onClick.RemoveAllListeners();
            UIConfirm.ButtonNo.onClick.RemoveAllListeners();
            UIConfirm.ButtonYes.onClick.AddListener(() => { CloseElements(onYes); });
            UIConfirm.ButtonNo.onClick.AddListener(() => { CloseElements(onNo); });
        }

        public void Prompt(string message, string title = "ENTER INFORMATION", string buttonCaption = "OK", string value = "", Action<string> onValueSet = null)
        {
            DisplayBackground();
            UIPrompt.gameObject.SetActive(true);
            UIPrompt.TextMessage.text = message;
            UIPrompt.TextTitle.text = title;
            UIPrompt.TextButtonOKCaption.text = buttonCaption;
            UIPrompt.InputFielPrompt.text = value;
            UIPrompt.ButtonOK.onClick.RemoveAllListeners();
            UIPrompt.ButtonCancel.onClick.RemoveAllListeners();

            UIPrompt.ButtonOK.onClick.AddListener(()=> { 
                CloseElements(() => { onValueSet?.Invoke(UIPrompt.InputFielPrompt.text); }); 
            }) ;
            UIPrompt.ButtonCancel.onClick.AddListener(() => { 
                CloseElements(() => { onValueSet?.Invoke(string.Empty); }); 
            });
        }

        #region Unility Functions
        private void DisplayBackground()
        {
            UIInfo.gameObject.SetActive(false);
            UIError.gameObject.SetActive(false);
            UIConfirm.gameObject.SetActive(false);
            UIPrompt.gameObject.SetActive(false);

            UIBackground.SetActive(true);
            CanvasGroup canvasGroup = UIBackground.GetComponent<CanvasGroup>();
            canvasGroup.alpha = 0;
            canvasGroup.DOFade(1, fadeDuration).SetEase(Ease.Linear);
        }

        private void CloseElements(Action onOK)
        {
            StartCoroutine(ICloseElements(onOK));
        }

        private IEnumerator ICloseElements(Action onOK)
        {
            CanvasGroup canvasGroup = UIBackground.GetComponent<CanvasGroup>();
            canvasGroup.DOFade(0, fadeDuration).SetEase(Ease.Linear);

            yield return new WaitForSeconds(fadeDuration);

            onOK?.Invoke();
            UIBackground.SetActive(false);
        }

        #endregion

    }

}

