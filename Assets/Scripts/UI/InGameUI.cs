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
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isUIVisible)
            {
                GameUI.SetActive(false);
                isUIVisible = false;
                //Time.timeScale = previousTimeScale;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Locked;
                //Debug.Log("1");
            }
            else
            {
                GameUI.SetActive(true);
                isUIVisible = true;
                //previousTimeScale = Time.timeScale; 
                //Time.timeScale = 0f; 
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                //Debug.Log("2");
            }
        }
    }
}