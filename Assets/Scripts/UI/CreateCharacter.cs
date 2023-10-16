using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class CreateCharacter : MonoBehaviour
{


    [Header("#InputField")]
    [SerializeField] private InputField inputField;
    public static string characterId = "";
    public Text characterNameText;
    public Text guideText;
    [SerializeField] private GameObject popup;
    [SerializeField] private GameObject horror;
    [SerializeField] private GameObject input;
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

        if (characterNameText == null)
        {
            // characterNameText가 null인 경우 초기화합니다.
            characterNameText = gameObject.AddComponent<Text>();
        }

        if (!string.IsNullOrEmpty(enteredName) && !enteredName.Contains(" ") && enteredName.Length <= 7)
        {
            characterNameText.text = enteredName;
            characterId = enteredName;

            popupText.text = enteredName + " (으)로 아이디를 생성하시겠습니까? ";
            popup.SetActive(true);
            horror.SetActive(true);
            input.SetActive(false);
            DontDestroyOnLoad(characterNameText);
        }
        else if (!string.IsNullOrEmpty(enteredName) && enteredName.Contains(" "))
        {
            guideText.text = "띄어쓰기는 불가능합니다!";
            textFadeOut.DisplayErrorMessage("띄어쓰기는 불가능합니다!");
        }
        else if (!string.IsNullOrEmpty(enteredName) && enteredName.Length >= 7)
        {
            guideText.text = "최대 7글자 이하만 가능합니다.";
            textFadeOut.DisplayErrorMessage("최대 7글자 이하만 가능합니다.");
        }
        else
        {
            guideText.text = "캐릭터 이름을 입력하세요";
            textFadeOut.DisplayErrorMessage("캐릭터 이름을 입력하세요");
        }
    }
}
