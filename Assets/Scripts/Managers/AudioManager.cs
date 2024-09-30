using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header("Musics")]
    public AudioClip BattleBGM;
    public AudioClip HudBGM;

    [Header("SFX")]
    public AudioClip botao;
    public AudioClip vitoria;
    public AudioClip derrota;

    public bool IsPaused = false;

    private void Start()
    {
        IsPaused = false;
    }

    private void Update()
    {
        if (IsPaused)
        {
            musicSource.Pause();
        }
        else
            musicSource.UnPause();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        IsPaused = false;
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void ButtonClick()
    {
        PlaySFX(botao);
    }
}