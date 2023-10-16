using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CreateCharacter : MonoBehaviour
{
 

    [Header("#InputField")]
    public InputField inputField;
    public static string characterId = "";
    public Text characterNameText;
    public Text guideText;
    public GameObject Popup;
    public TextFadeOut textFadeOut;
    [Header("\n")]
    public Text popupText;

    private void Start()
    {
        characterNameText = gameObject.AddComponent<Text>();
    }

    public void GenerateCharacterName()
    {
        string enteredName = inputField.text;
        if (!string.IsNullOrEmpty(enteredName) && !enteredName.Contains(" ") && enteredName.Length <= 6)
        {
            characterNameText.text = enteredName;
            characterId = enteredName;

            popupText.text = enteredName+ " (��)�� ���̵� �����Ͻðڽ��ϱ�? ";
            Popup.SetActive(true);
            DontDestroyOnLoad(characterNameText);
        }
        else if (!string.IsNullOrEmpty(enteredName) && enteredName.Contains(" "))
        {
            guideText.text = "����� �Ұ����մϴ�!";
            textFadeOut.DisplayErrorMessage("����� �Ұ����մϴ�!");
        }
        else if (!string.IsNullOrEmpty(enteredName) && enteredName.Length >= 6)
        {
            guideText.text = "�ִ� 6���� ���ϸ� �����մϴ�.";
            textFadeOut.DisplayErrorMessage("�ִ� 6���� ���ϸ� �����մϴ�.");
        }
        else 
        {
            guideText.text = "ĳ���� �̸��� �Է��ϼ���";
            textFadeOut.DisplayErrorMessage("ĳ���� �̸��� �Է��ϼ���");
        }
    }
}
