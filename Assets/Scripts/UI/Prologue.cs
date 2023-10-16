using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Prologue : MonoBehaviour
{
    private bool skipPrologue = false;
    public Text prologueText;
    public AudioClip typeSound;

    private void Start()
    {
        StartCoroutine(PlayPrologue());
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
        string prologueMessage = "�׽�Ʈ1 Ÿ���� Ȯ�� ";

        for (int i = 0; i < prologueMessage.Length; i++)
        {
            if (skipPrologue)
            {
                break;
            }

            prologueText.text += prologueMessage[i];
            if (prologueMessage[i] != ' ' && prologueMessage[i] != ',')
            {
                PlaySound(typeSound);
            }

            yield return new WaitForSeconds(0.2f);
        }

        yield return new WaitForSeconds(0.5f);
        prologueText.text = "";

        string prologueMessage2 = "�׽�Ʈ2 Ÿ���� Ȯ�� ";

        for (int i = 0; i < prologueMessage2.Length; i++)
        {
            if (skipPrologue)
            {
                break;
            }

            prologueText.text += prologueMessage2[i];
            if (prologueMessage2[i] != ' ' && prologueMessage2[i] != ',')
            {
                PlaySound(typeSound);
            }

            yield return new WaitForSeconds(0.2f);


        }
    }

    private void PlaySound(AudioClip audioClip)
    {
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = audioClip;

        // ���� ����ӵ� ����
        audioSource.pitch = 1.5f;
        audioSource.Play();
    }
}