using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource Musicsource;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject imageObject; 
    

    public void SetMusicVolume(float volume)
    {

        Musicsource.volume = volume;
        if (slider.value == 0)
        {
            imageObject.SetActive(true);
        }
        else
        {
            imageObject.SetActive(false);
        }
    }

    public void SetMute()
    {
        if (slider.value == 0)
        {
            slider.value = 1;
            imageObject.SetActive(false);
        }
        else
        {
            slider.value = 0;
            imageObject.SetActive(true);
        }
        
   
    }
}
