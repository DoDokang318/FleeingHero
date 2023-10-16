using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource Musicsource;
    [SerializeField] private Slider slider;
    //[SerializeField] private GameObject imageObject; 
    

    public void SetMusicVolume(float volume)
    {
        Musicsource.volume = volume;
    }
}
