using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Transform mainCamera; // ��鸱 ī�޶��� Transform ������Ʈ
    public float shakeDuration = 5.0f; // ��鸱 �ð�
    public float shakeIntensity = 0.2f; // ��鸲�� ����

    private Vector3 initialPosition; // �ʱ� ī�޶� ��ġ
    private float currentShakeDuration = 0.0f;

    void Start()
    {
        initialPosition = mainCamera.localPosition;
    }

    void Update()
    {
        if (currentShakeDuration > 0)
        {
            float offsetX = Random.Range(-1f, 1f) * shakeIntensity;
            Vector3 newPosition = initialPosition + new Vector3(offsetX, 0, 0);

            mainCamera.localPosition = newPosition;
            currentShakeDuration -= Time.deltaTime;
        }
        else
        {
            currentShakeDuration = 0.0f;
            mainCamera.localPosition = initialPosition;
        }
    }

    public void StartShake()
    {
        if (currentShakeDuration <= 0)
        {
            currentShakeDuration = shakeDuration;
        }
    }
}