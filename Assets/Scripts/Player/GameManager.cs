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
       // PlayerSpqwn();
    }

    public void Die(GameObject gameObject)
    {
        Destroy(gameObject);
        Debug.Log("Á×À½ ");
        IsGameOver = true;
    }

    public void PlayerSpqwn()
    {
        Instantiate(Player, Spawn.transform);
    }


}
