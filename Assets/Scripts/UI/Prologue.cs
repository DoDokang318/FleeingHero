using System.Collections;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class Prologue : MonoBehaviour
{
    private bool skipPrologue = false;
    public Text prologueText;
    public CreateCharacter createCharacter;
    public ParticleSystem particle;
    public ParticleSystem particle2;
    public GameObject btn;
    public GameObject Canvas;
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
        string prologueMessage = "��� " + CreateCharacter.characterId + "����, �Ͼ����... ";

        for (int i = 0; i < prologueMessage.Length; i++)
        {
            //if (skipPrologue)
            //{
            //    break;
            //}

            prologueText.text += prologueMessage[i];
            if (prologueMessage[i] != ' ' && prologueMessage[i] != ',')
            {

                AudioManagers.I.PlaySound(0);


            }

            yield return new WaitForSeconds(fast == 0 ? 0.2f : fast == 1 ? 0.1f : 0.05f);
        }
        yield return new WaitForSeconds(0.5f);
        prologueText.text = "";

        string prologueMessage2 = "(�� ����... ������ �� �ڰ� �־��µ�)";

        for (int i = 0; i < prologueMessage2.Length; i++)
        {
            //if (skipPrologue)
            //{
            //    break;
            //}

            prologueText.text += prologueMessage2[i];
            if (prologueMessage2[i] != ' ' && prologueMessage2[i] != ',' && prologueMessage2[i] != '(' && prologueMessage2[i] != ')')
            {
                AudioManagers.I.PlaySound(0);
            }
            yield return new WaitForSeconds(fast == 0 ? 0.2f : fast == 1 ? 0.1f : 0.05f);
        }

        yield return new WaitForSeconds(0.5f);
        prologueText.text = "";

        string prologueMessage3 = CreateCharacter.characterId + "���� �տ�, ���� �ձ��� �̷��� �޷��ֽ��ϴ�.";

        for (int i = 0; i < prologueMessage3.Length; i++)
        {
            //if (skipPrologue)
            //{
            //    break;
            //}

            prologueText.text += prologueMessage3[i];
            if (prologueMessage3[i] != ' ' && prologueMessage3[i] != ',')
            {
                AudioManagers.I.PlaySound(0);
            }
            yield return new WaitForSeconds(fast == 0 ? 0.2f : fast == 1 ? 0.1f : 0.05f);
        }

        yield return new WaitForSeconds(1.0f);
        prologueText.text = "";
        particle.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        string prologueMessage4 = "���� �������� ����, �� ���� ���Ϸ� ���ּ���!!!";
        prologueText.color = Color.black;
        for (int i = 0; i < prologueMessage4.Length; i++)
        {
            //if (skipPrologue)
            //{
            //    break;
            //}

            prologueText.text += prologueMessage4[i];
            if (prologueMessage4[i] != ' ' && prologueMessage4[i] != ',')
            {
                AudioManagers.I.PlaySound(0);
            }
            yield return new WaitForSeconds(fast == 0 ? 0.2f : fast == 1 ? 0.1f : 0.05f);
        }
        yield return new WaitForSeconds(1.5f);
        AudioManagers.I.PitchCheck = false;
        LoadScene("Merge3");
        Destroy(prologueText.gameObject);
        Destroy(particle);
        Destroy(particle2);
        Destroy(btn.gameObject);
        Destroy(Canvas);
    }
    public void ButtonFast()
    {
        if (fast >= 0 && fast <= 1)
        {
            fast += 1;
        }
    }

    public void LoadScene(string Merge3)
    {
        SceneManager.LoadScene(Merge3);
    }

}