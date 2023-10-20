using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class Prologue2 : MonoBehaviour
{
    private bool skipPrologue = false;
    public Text prologueText;
    private int fast;
    private void Start()
    {
        StartCoroutine(PlayPrologue());
        AudioManagers.I.PitchCheck = true;

    }

    private void Update()
    {
        //if (Input.anyKeyDown)
        //{
        //    skipPrologue = true;
        //}
    }

    private IEnumerator PlayPrologue()
    {
        string prologueMessage = "���� �� �ڰ� �־��µ�... ���ݸ� �� �־����� ������� ������ �� �־��µ� ���̾�. ";

        for (int i = 0; i < prologueMessage.Length; i++)
        {
            prologueText.text += prologueMessage[i];
            if (prologueMessage[i] != ' ' && prologueMessage[i] != ',')
            {
                //AudioManagers.I.PlaySound(0);
            }

            yield return new WaitForSeconds( 0.08f );
        }
        yield return new WaitForSeconds(0.5f);
        prologueText.text = "";

        string prologueMessage2 = "..............???";

        for (int i = 0; i < prologueMessage2.Length; i++)
        {
            prologueText.text += prologueMessage2[i];
            if (prologueMessage2[i] != ' ' && prologueMessage2[i] != ',' && prologueMessage2[i] != '(' && prologueMessage2[i] != ')')
            {
                //AudioManagers.I.PlaySound(0);
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.5f);
        prologueText.text = "";

        string prologueMessage3 = "����...!? ���� ����?? ���� �� �� �̷����� �־�?";

        for (int i = 0; i < prologueMessage3.Length; i++)
        {
            prologueText.text += prologueMessage3[i];
            if (prologueMessage3[i] != ' ' && prologueMessage3[i] != ',' )
            {
                //AudioManagers.I.PlaySound(0);
            }
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(0.5f);
        prologueText.text = "";

        string prologueMessage4 = "��... ���� ���� �����?? Ȧ�� �F! �����������!!!";

        for (int i = 0; i < prologueMessage4.Length; i++)
        {
            prologueText.text += prologueMessage4[i];
            if (prologueMessage4[i] != ' ' && prologueMessage4[i] != ',')
            {
                //AudioManagers.I.PlaySound(0);
            }
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(1.0f);
        prologueText.text = "";

        string prologueMessage5 = "(������ ���ٵ��, ���踦 ã�� ���� Ż���غ����� ����)";

        for (int i = 0; i < prologueMessage5.Length; i++)
        {
            prologueText.text += prologueMessage5[i];
            if (prologueMessage5[i] != ' ' && prologueMessage5[i] != ',')
            {
                //AudioManagers.I.PlaySound(0);
            }
            yield return new WaitForSeconds(0.1f);
        }

        prologueText.text = "";


    }



}