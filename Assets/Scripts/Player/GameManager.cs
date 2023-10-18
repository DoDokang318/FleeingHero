using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject Spawn;
    private bool isgameOver;
    public bool IsGameOver { get { return isgameOver; } set { isgameOver = value; } }


    
    private void Awake()
    {
        I = this;       
       DontDestroyOnLoad(gameObject);
        
    }
    void Start()
    {
        PlayerSpqwn();
    }

    public void Die()
    {
        Destroy(Player);
        Debug.Log("죽음 ");
        IsGameOver = true;

        if (GameManager.I.IsGameOver == true)
        {
            //게임 오버 UI



        }
    }

    public void PlayerSpqwn()
    {
        Instantiate(Player, Spawn.transform);
    }


}
