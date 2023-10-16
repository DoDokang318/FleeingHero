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

            popupText.text = enteredName+ " (으)로 아이디를 생성하시겠습니까? ";
            Popup.SetActive(true);
            DontDestroyOnLoad(characterNameText);
        }
        else if (!string.IsNullOrEmpty(enteredName) && enteredName.Contains(" "))
        {
            guideText.text = "띄어쓰기는 불가능합니다!";
            textFadeOut.DisplayErrorMessage("띄어쓰기는 불가능합니다!");
        }
        else if (!string.IsNullOrEmpty(enteredName) && enteredName.Length >= 6)
        {
            guideText.text = "최대 6글자 이하만 가능합니다.";
            textFadeOut.DisplayErrorMessage("최대 6글자 이하만 가능합니다.");
        }
        else 
        {
            guideText.text = "캐릭터 이름을 입력하세요";
            textFadeOut.DisplayErrorMessage("캐릭터 이름을 입력하세요");
        }
    }
}
