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
        // 인스펙터 온클릭을 사용하지 않고 코드로 사용함
        btnBack.onClick.AddListener(Close);
        btnYes.onClick.AddListener(OpenUI);
        btnNo.onClick.AddListener(Close);
    }
    void OpenUI()
    {

        //상점 오브젝트 UI
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
        // 한번 눌르는 인터렉션이 사용될때 // 그게 아니라면 그냥 갯키
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }
}
