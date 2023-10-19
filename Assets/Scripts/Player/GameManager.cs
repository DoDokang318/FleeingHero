using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Spawn;
    [SerializeField] private GameObject Youdie;
    private bool isgameOver;
    public bool IsGameOver { get { return isgameOver; } set { isgameOver = value; } }


    
    private void Awake()
    {
        I = this;       
       DontDestroyOnLoad(gameObject);
        
    }
    void Start()
    {
       // PlayerSpqwn();
    }

    public void Die(GameObject gameObject)
    {
        Destroy(gameObject);
        Debug.Log("Á×À½ ");
        IsGameOver = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Youdie.SetActive(true);

    }

    public void PlayerSpqwn()
    {
        Instantiate(Player, Spawn.transform);
    }


}
