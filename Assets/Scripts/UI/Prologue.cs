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
        string prologueMessage = "���� ����, ������ ���ϱ� ���� ������ ���� ��� ";

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

        string prologueMessage2 = "�׽�Ʈ2 Ÿ���� Ȯ�� �����Űܰ��������� ";

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


            // �𸣰ڴµ� ��ø�
        }
        Audiomanagers.PitchCheck = false;
    }

}