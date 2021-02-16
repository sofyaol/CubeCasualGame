using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameState
{
    static long maxScore = 0;

    internal static bool Pause { get; set; } = false;

    private static bool isSoundOn = true;
    internal static bool IsSoundOn
    { get { return isSoundOn; }
        set
        {
            isSoundOn = value;
        }
    }


    static internal Queue<int> cubesCountQueue = new Queue<int>(); // очередь кол-ва кубиков в gate
    static internal Queue<int> gateCountQueue = new Queue<int>(); // очередь кол-ва gate'ов

    internal static void MakePause()
    {
        Time.timeScale = 0;
        Pause = true;
    }

    internal static void Unpause()
    {
        Time.timeScale = 1;
         Pause = false; 
    }

    internal static void SetGameStartCondition()
    {
        GameState.gateCountQueue.Clear();
        GameState.cubesCountQueue.Clear();

        MaterialAppointer.IndexOfActualMaterial = 0;

        Player.DestroyedCount = 0;
        Player.Score = 0;
        Player.Points = 0;

        PlayerDeath.IsDead = false;

        Platform.SetSpeed(0.1f);
    
    }

    internal static void SetMaxScore(long maxScore)
    {
        GameState.maxScore = maxScore;
    }

    internal static long GetMaxScore()
    {
        return GameState.maxScore;
    }

 
}
