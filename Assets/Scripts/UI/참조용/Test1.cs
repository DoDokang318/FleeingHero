using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{
    [SerializeField] private TMP_Text txtTitle;
    [SerializeField] private TMP_Text txtContent;

    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnYes;
    [SerializeField] private Button btnNo;

    // 리터값이 없다면 액션을 델리게이트로 사용가능
    private Action OnConfirm;

    void Start()
    {
        btnBack.onClick.AddListener(Close);
        btnYes.onClick.AddListener(confirm);
        btnNo.onClick.AddListener(Close);
    }

    // 액션은 참조형식의 기본값은 Null
    // 숫자 기본값 0 / Bool 기본값 False
    public void SetPopup(string title, string content, Action onConfirm = null)
    {
        txtTitle.text = title;
        txtContent.text = content;

        OnConfirm = onConfirm;
    }

    void confirm()
    {
        if (OnConfirm != null)
        {
            OnConfirm();
            OnConfirm = null;
        }

        // 위에 OnConfirm?.Invoke(); 로 대체가능

        Close();
    }

    void Close()
    {
        gameObject.SetActive(false);
    }
}
