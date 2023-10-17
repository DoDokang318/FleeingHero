using UnityEngine;

public class LightFading : MonoBehaviour
{
    public Light centralLight; // ���� �߻��ϴ� �߽� ��(Light) ������Ʈ
    public float fadeDuration = 5.0f; // ���� ������� �ð�
    public float maxIntensity = 8.0f; // ���� �ִ� ����

    private float currentFadeTime = 0.0f;

    void Start()
    {
        centralLight.intensity = 0; // �ʱ⿡ ���� ���Ӵϴ�.
    }

    public void Light()
    {
        if (currentFadeTime < fadeDuration)
        {
            // ���� ���� ������ ���� ������ŵ�ϴ�.
            currentFadeTime += Time.deltaTime;
            float t = currentFadeTime / fadeDuration;
            centralLight.intensity = Mathf.Lerp(0, maxIntensity, t);
        }
    }
}