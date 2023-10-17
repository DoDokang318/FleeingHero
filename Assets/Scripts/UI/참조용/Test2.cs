using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;

public class Gate : MonoBehaviour
{
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnYes;
    [SerializeField] private Button btnNo;

    private void Start()
    {
        // �ν����� ��Ŭ���� ������� �ʰ� �ڵ�� �����
        btnBack.onClick.AddListener(Close);
        btnYes.onClick.AddListener(OpenUI);
        btnNo.onClick.AddListener(Close);
    }
    void OpenUI()
    {

        //���� ������Ʈ UI
        //UIManager.Instance.OpenUI<UIshop>();

        Close();
    }
    void Close()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // �ѹ� ������ ���ͷ����� ���ɶ� // �װ� �ƴ϶�� �׳� ��Ű
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }
}
