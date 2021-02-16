using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public sealed class MenuController : MonoBehaviour
{
    public Text score;
    public float duration = 1f;

    void Start()
    {
        GameState.SetMaxScore(SaveGame.Load());
        score.text = GameState.GetMaxScore().ToString();

        DOVirtual.Float(0f, GameState.GetMaxScore(), duration, (v) => score.text = Mathf.Floor(v).ToString());
    }
}
