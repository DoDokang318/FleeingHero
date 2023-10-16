using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Musicsource;
    public Slider slider;
    public GameObject imageObject; 
    

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
