using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public sealed class PlayerDeath : MonoBehaviour
{
    static GameObject gameOverPanel;
    static GameObject scoreText; 

    float deathTime = 0.6f;

    static bool isDead = false;
    static bool OnTrigger { set; get; } = false; // if one cube is triggered than other won't considered 

    internal static bool IsDead{ get { return isDead; }
        set
        {
            isDead = value;

            if (value == true && !OnTrigger)
            {
                OnTrigger = true;

                GameState.MakePause(); // !!!! ?????? !!!!!!

                gameOverPanel.SetActive(true);
                 
                scoreText = gameOverPanel.transform.FindChild("ScoreText").gameObject;
                scoreText.GetComponent<Text>().text = Player.Score.ToString();
                

                
                long maxScore = Player.Score > GameState.GetMaxScore() ? Player.Score : GameState.GetMaxScore();
                SaveGame.Save(maxScore);

                GameState.SetGameStartCondition();
            }
          
        }
    }

  

    void  OnTriggerEnter(Collider name)
    {
     
        if (name.tag == "Gate" || name.tag == "Death")
        {
            
            Platform.SetSpeed(0);
            GameState.Pause = true;

            if (name.tag == "Gate")
            {
               transform.DOScale(0.05f, 2f).SetEase(Ease.InCubic);


                Camera.main.transform.DOMove(transform.position - new Vector3(0f, -0.5f, 1.5f), 2f)
                    .OnComplete(() =>DeathAction(deathTime));
            }

            else
            {
                DeathAction(deathTime);
            }

        }
    }

    private void DeathAction(float time)
    {
        PlayerPhysics.DeathExplosion();
        SoundManager.GameOverSoundPlay();
        Invoke("MakeDead", time);
    }

    void Start()
    {
        OnTrigger = false;
       
        if (GameObject.Find("GameOverPanel") != null)
        {
            gameOverPanel = GameObject.Find("GameOverPanel");
            gameOverPanel.SetActive(false);
        }
    }

    void MakeDead()
    {
        IsDead = true;
    }

}
