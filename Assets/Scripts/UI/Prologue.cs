using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Prologue : MonoBehaviour
{
    private bool skipPrologue = false;
    public Text prologueText;
    public AudioManagers Audiomanagers;

    private void Start()
    {
        StartCoroutine(PlayPrologue());
        Audiomanagers.PitchCheck = true;
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
        string prologueMessage = "옛날 옛적, 세상을 구하기 위해 모험을 떠난 용사 ";

        for (int i = 0; i < prologueMessage.Length; i++)
        {
            if (skipPrologue)
            {
                break;
            }

            prologueText.text += prologueMessage[i];
            if (prologueMessage[i] != ' ' && prologueMessage[i] != ',')
            {
                
                Audiomanagers.PlaySound(0);
           

            }

            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.5f);
        prologueText.text = "";

        string prologueMessage2 = "테스트2 타이핑 확인 가갸거겨고교구규으이 ";

        for (int i = 0; i < prologueMessage2.Length; i++)
        {
            if (skipPrologue)
            {
                break;
            }

            prologueText.text += prologueMessage2[i];
            if (prologueMessage2[i] != ' ' && prologueMessage2[i] != ',')
            {
                Audiomanagers.PlaySound(0);
            }

            yield return new WaitForSeconds(0.2f);


            // 모르겠는데 잠시만
        }
        Audiomanagers.PitchCheck = false;
    }

}