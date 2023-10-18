using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public GameObject GameUI;
    private bool isUIVisible = false;
    private float previousTimeScale;

    private void Start()
    {
        previousTimeScale = Time.timeScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isUIVisible)
            {
                GameUI.SetActive(false);
                isUIVisible = false;
                Time.timeScale = previousTimeScale; // ������ �ð� ������ ����
                Cursor.visible = true;
            }
            else
            {
                GameUI.SetActive(true);
                isUIVisible = true;
                previousTimeScale = Time.timeScale; // ������ �ð� ���� ����
                Time.timeScale = 0f; // �ð� ����
                Cursor.visible = true;
            }
        }
    }
}