using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreController : MonoBehaviour
{
    internal static Text scoreText;

    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    internal static void SetScore(long score)
    {
        scoreText.text = score.ToString();
    }
}
