using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class Buttons : MonoBehaviour
{
    public Sprite soundOn;
    public Sprite soundOff;

    public Sprite pauseOn;
    public Sprite pauseOff;

    public GameObject soundButton;
    public GameObject pauseButton;

    public void Start()
    {
        if (soundButton != null)
        {
            if (!GameState.IsSoundOn)
            {
                soundButton.GetComponent<Image>().sprite = soundOff;
            }
        }
    }
    
    public void ClickOnPlayButton()
    {
        SoundManager.ButtonSoundPlay();
        SceneManager.LoadScene("Game");
    }


    public void ClickOnHomeButton()
    {
        SoundManager.ButtonSoundPlay();

        long maxScore = Player.Score > GameState.GetMaxScore() ? Player.Score : GameState.GetMaxScore();
        SaveGame.Save(maxScore);

        GameState.SetGameStartCondition(); 

        if (GameState.Pause == true)
        {
            GameState.Unpause();
        }
        
       SceneManager.LoadScene("Menu");
    }

    public void ClickOnPauseButton()
    {
        SoundManager.ButtonSoundPlay();

        if (!GameState.Pause)
        {
            GameState.MakePause();
            pauseButton.GetComponent<Image>().sprite = pauseOn;

        }

        else
        {
            GameState.Unpause();
            pauseButton.GetComponent<Image>().sprite = pauseOff;
        }
    }

    public void ClickOnSoundButton()
    {
        if (GameState.IsSoundOn)
        {
            GameState.IsSoundOn = false;
            soundButton.GetComponent<Image>().sprite = soundOff;
        }

        else
        {
            GameState.IsSoundOn = true;
            soundButton.GetComponent<Image>().sprite = soundOn;
        }

        SoundManager.ButtonSoundPlay();
    }

    public void ClickOnGameoverButton()
    {

        GameState.Unpause();

        PlayerDeath.IsDead = false;
        SceneManager.LoadScene("Menu");
    }
}
