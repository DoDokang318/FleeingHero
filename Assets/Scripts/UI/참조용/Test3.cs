using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Delegates : MonoBehaviour
{
    [SerializeField] private Button btnBack;
    [SerializeField] private Button btnYes;
    [SerializeField] private Button btnNo;
    // Start is called before the first frame update
    void Start()
    {
        //btnBack.onClick.AddListener(Close);
        //btnYes.onClick.AddListener(OpenUI);
        //btnNo.onClick.AddListener(Close);
    }

    void OpenPopup_Shop()
    {
        //UIPopup popup = UIManager.Instance.OpenUI<UIPopup>();
        //popup.SetPopup("����","���ðڽ��ϱ�",OpenShop)
    }

    void Openshop()
    {
        //UIManager.Instance.OpenUI<UIShop>();
    }

    void OpenPopup_Inventory()
    {
        // UIPopup popup = UIManager.Instance.OpenUI<UIPopup>();
        // popup.SetPopup("�κ��丮","���ðڽ��ϱ�",OpenInventory)
    }
    void OpenInventory()
    {
        //UIManager.Instance.OpenUI<UIShop>();
    }


    void Update()
    {
        
    }
}
