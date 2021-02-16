using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SoundManager : MonoBehaviour
{
    static AudioSource DestroyAudio { get; set; }
    static AudioSource ButtonAudio { get; set; }
    static AudioSource RestoreAudio { get; set; }
    static AudioSource GameOverAudio { get; set; }

    public void Start()
    {
        DestroyAudio = new GameObject("DestroySoundObject").AddComponent<AudioSource>();
        DestroyAudio.clip = (AudioClip) Resources.Load("Sounds/DestroyCubeSound1");
        
        ButtonAudio = new GameObject("ButtonSoundObject").AddComponent<AudioSource>();
        ButtonAudio.clip = (AudioClip) Resources.Load("Sounds/ButtonSound");

        RestoreAudio = new GameObject("RestoreSoundObject").AddComponent<AudioSource>();
        RestoreAudio.clip = (AudioClip)Resources.Load("Sounds/RestoreSound1");

        GameOverAudio = new GameObject("GameOverSoundObject").AddComponent<AudioSource>();
        GameOverAudio.clip = (AudioClip)Resources.Load("Sounds/GameOver");

    }

    public static void DestroySoundPlay()
    {
        if(GameState.IsSoundOn)
        DestroyAudio.Play();
        
    }

    public static void ButtonSoundPlay()
    {
        if (GameState.IsSoundOn)
            ButtonAudio.Play();
    }

    public static void RestoreSoundPlay()
    {
        if (GameState.IsSoundOn)
            RestoreAudio.Play();
    }

    public static void GameOverSoundPlay()
    {
        if (GameState.IsSoundOn)
            GameOverAudio.Play();
    }


}
