using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] images;
    private int currentImageIndex = 0;
    public AudioManagers Audiomanagers;

    private void Start()
    {
        // 첫번째 이미지 활성화
        ToggleImage(currentImageIndex);
        Audiomanagers.PitchCheck = false;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            ToggleImage(currentImageIndex, false);

            currentImageIndex = (currentImageIndex + 1) % images.Length;

            ToggleImage(currentImageIndex, true);
            ToggleImage((currentImageIndex + 1) % images.Length, true);

            Audiomanagers.PlaySound(1);
        }
    }

    private void ToggleImage(int index, bool isActive = true)
    {
        if (index >= 0 && index < images.Length)
        {
            images[index].SetActive(isActive);
        }
    }
}