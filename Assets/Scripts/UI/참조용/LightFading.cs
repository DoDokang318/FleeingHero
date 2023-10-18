using UnityEngine;

public class LightFading : MonoBehaviour
{
    public Light centralLight; // 빛이 발생하는 중심 빛(Light) 컴포넌트
    public float fadeDuration = 5.0f; // 빛이 밝아지는 시간
    public float maxIntensity = 8.0f; // 빛의 최대 강도

    private float currentFadeTime = 0.0f;

    void Start()
    {
        centralLight.intensity = 0; // 초기에 빛을 꺼둡니다.
    }

    public void Light()
    {
        if (currentFadeTime < fadeDuration)
        {
            // 현재 빛의 강도를 점차 증가시킵니다.
            currentFadeTime += Time.deltaTime;
            float t = currentFadeTime / fadeDuration;
            centralLight.intensity = Mathf.Lerp(0, maxIntensity, t);
        }
    }
}