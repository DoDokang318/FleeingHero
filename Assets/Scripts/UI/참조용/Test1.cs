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

    // ���Ͱ��� ���ٸ� �׼��� ��������Ʈ�� ��밡��
    private Action OnConfirm;

    void Start()
    {
        btnBack.onClick.AddListener(Close);
        btnYes.onClick.AddListener(confirm);
        btnNo.onClick.AddListener(Close);
    }

    // �׼��� ���������� �⺻���� Null
    // ���� �⺻�� 0 / Bool �⺻�� False
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

        // ���� OnConfirm?.Invoke(); �� ��ü����

        Close();
    }

    void Close()
    {
        gameObject.SetActive(false);
    }
}
