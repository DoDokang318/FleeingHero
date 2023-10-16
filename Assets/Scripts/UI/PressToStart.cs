using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject[] images;
    private int currentImageIndex = 0;

    private void Start()
    {
        // ù��° �̹��� Ȱ��ȭ
        ToggleImage(currentImageIndex);
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            ToggleImage(currentImageIndex, false);

            currentImageIndex = (currentImageIndex + 1) % images.Length;

            ToggleImage(currentImageIndex, true);
            ToggleImage((currentImageIndex + 1) % images.Length, true);
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