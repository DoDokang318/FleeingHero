using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Prologue : MonoBehaviour
{
    private bool skipPrologue = false;
    public Text prologueText;
    public AudioManagers audioManagers;
    public CreateCharacter createCharacter;

    private void Start()
    {
        StartCoroutine(PlayPrologue());
        audioManagers.PitchCheck = true;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            skipPrologue = true;
        }
    }

    private IEnumerator PlayPrologue()
    {
        string prologueMessage = "용사 " + CreateCharacter.characterId + "♥여, 어서 일어나게... ";

        for (int i = 0; i < prologueMessage.Length; i++)
        {
            if (skipPrologue)
            {
                break;
            }

            prologueText.text += prologueMessage[i];
            if (prologueMessage[i] != ' ' && prologueMessage[i] != ',')
            {
                
                audioManagers.PlaySound(0);
           

            }

            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.5f);
        prologueText.text = "";

        string prologueMessage2 = "아 뭐야... 잘 자고 있었는데";

        for (int i = 0; i < prologueMessage2.Length; i++)
        {
            if (skipPrologue)
            {
                break;
            }

            prologueText.text += prologueMessage2[i];
            if (prologueMessage2[i] != ' ' && prologueMessage2[i] != ',')
            {
                audioManagers.PlaySound(0);
            }
            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(0.5f);
        prologueText.text = "";

        string prologueMessage3 = "텍스트 3 테스트용";

        for (int i = 0; i < prologueMessage3.Length; i++)
        {
            if (skipPrologue)
            {
                break;
            }

            prologueText.text += prologueMessage3[i];
            if (prologueMessage3[i] != ' ' && prologueMessage3[i] != ',')
            {
                audioManagers.PlaySound(0);
            }
            yield return new WaitForSeconds(0.2f);
        }
        audioManagers.PitchCheck = false;
    }

}