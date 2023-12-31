using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public GameObject GameUI;
    private bool isUIVisible = false;
    private float previousTimeScale;

    private void Start()
    {
        previousTimeScale = Time.timeScale;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isUIVisible)
            {
                GameUI.SetActive(false);
                isUIVisible = false;
                Time.timeScale = previousTimeScale;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Locked;
                AudioManagers.I.PlaySound(1);
            }
            else
            {
                GameUI.SetActive(true);
                isUIVisible = true;
                previousTimeScale = Time.timeScale; 
                Time.timeScale = 0f; 
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                AudioManagers.I.PlaySound(1);
            }
        }
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}