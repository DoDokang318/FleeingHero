using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public Text name;
    private void Start()
    {
        name.text = CreateCharacter.characterId;
        // name.text = CreateCharacter.characterNameText.text;

        //Debug.Log(PlayerPrefs.GetString("Name"));
        // name.text = PlayerPrefs.GetString("Name");
        //float playerPrefsStartTime = Time.realtimeSinceStartup;

        //for (int i = 0; i < 100000; i++)
        //{
        //    PlayerPrefs.SetString("Key" + i, "Value" + i);
        //}
        //float playerPrefsEndTime = Time.realtimeSinceStartup;
        //Debug.Log("PlayerPrefs Time: " + (playerPrefsEndTime - playerPrefsStartTime) + " seconds");
        //float variableStartTime = Time.realtimeSinceStartup;
        //string[] variables = new string[100000];
        //for (int i = 0; i < 100000; i++)
        //{
        //    variables[i] = "Value" + i;
        //}
        //float variableEndTime = Time.realtimeSinceStartup;
        //Debug.Log("Variable Time: " + (variableEndTime - variableStartTime));   

    }
}
