using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagers : MonoBehaviour
{

    public static AudioManagers I;
    private void Awake()
    {
        I = this;
        Init();
    }

    [Header("#BGM")]
    //public Dropdown bgmDropdown;
    public AudioSource bgmPlayer;
    public AudioClip bgmClip;
    public float bgmVolume;
    public Slider bgm_Slider;

    [Header("#SFX")]
    public AudioSource sfxPlayer;
    public AudioClip[] sfxClip;
    public float sfxVolume;
    public Slider sfx_Slider;

    [Header("MonsterAudio")]
    public AudioSource sfxMonsterPlayer;
    public AudioClip[] sfxMonsterNormal;
    public AudioClip sfxMonsterFollow;

    public bool PitchCheck = true;

    private void Init()
    {     
        
        bgmPlayer.volume = bgmVolume;
        bgmPlayer.clip = bgmClip;

        sfxPlayer.volume = sfxVolume;
    }

    public void SetMusicVolume(float volume)
    {
        bgmPlayer.volume = volume;
    }
    
    public void SetsfxVolume(float volume)
    {
        sfxPlayer.volume = volume;
    }

    public void PlaySound(int index)
    {
        if (sfxPlayer == null)
        {
            Debug.Log("효과음 소스가 없어요");
        }
        sfxPlayer.PlayOneShot(sfxClip[index]);
        
        if(PitchCheck)
        sfxPlayer.pitch = 1.5f;
        else
        sfxPlayer.pitch = 1f;
    }
    public void ClickSound()
    {
        PlaySound(1);
    }

    public void scream()
    {
        PlaySound(2);
    }

}