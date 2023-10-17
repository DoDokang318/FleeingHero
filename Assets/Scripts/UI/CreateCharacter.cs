using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CreateCharacter : MonoBehaviour
{


    [Header("#InputField\n")]
    [SerializeField] private InputField inputField;
    public static string characterId = "";
    [SerializeField] private Text characterNameText;
    [SerializeField] private Text guideText;
    [SerializeField] private AudioManagers Audiomanagers;
    [Header("\n#Popup")]
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject horror;
    [SerializeField] private GameObject input;
    [SerializeField] private TextFadeOut textFadeOut;
    [SerializeField] private Text popupText;

    private void Start()
    {
        characterNameText = gameObject.AddComponent<Text>();
    }

    public void GenerateCharacterName()
    {
        string enteredName = inputField.text;

        if (characterNameText == null)
        {
            // characterNameText�� null�� ��� �ʱ�ȭ�մϴ�.
            characterNameText = gameObject.AddComponent<Text>();
        }

        if (!string.IsNullOrEmpty(enteredName) && !enteredName.Contains(" ") && enteredName.Length <= 7)
        {
            characterNameText.text = enteredName;
            characterId = enteredName;

            popupText.text = enteredName + " (��)�� ���̵� �����Ͻðڽ��ϱ�? ";
            popup.SetActive(true);
            horror.SetActive(true);
            input.SetActive(false);
            Audiomanagers.PlaySound(2);
            DontDestroyOnLoad(characterNameText);
        }
        else if (!string.IsNullOrEmpty(enteredName) && enteredName.Contains(" "))
        {
            guideText.text = "����� �Ұ����մϴ�!";
            textFadeOut.DisplayErrorMessage("����� �Ұ����մϴ�!");
        }
        else if (!string.IsNullOrEmpty(enteredName) && enteredName.Length >= 7)
        {
            guideText.text = "�ִ� 7���� ���ϸ� �����մϴ�.";
            textFadeOut.DisplayErrorMessage("�ִ� 7���� ���ϸ� �����մϴ�.");
        }
        else
        {
            guideText.text = "ĳ���� �̸��� �Է��ϼ���";
            textFadeOut.DisplayErrorMessage("ĳ���� �̸��� �Է��ϼ���");
        }
    }
}
