using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    // скрипт прикреплен к RestoreMarker

    void OnTriggerEnter(Collider name)
    {
        if (name.tag == "Player")
        {

            // СЧИТАЕМ ОЧКИ

            
            int gateCount = GameState.gateCountQueue.Dequeue();

            Debug.Log("gate count: " + gateCount);

            for (int i = 0; i < gateCount; i++)
            {
                Player.Points += GameState.cubesCountQueue.Dequeue(); // сколько было кубиков за всю платформу
                Debug.Log("cubes count: " + Player.Points);
            }

              Debug.Log("Points for platform: " + Player.Points); // points = cubes for 1 platform

            int diff = Player.DestroyedCount - Player.Points; // 
            Player.Points =  diff > 0 ? Player.Points - diff : Player.Points; 

            // ДОБАВЛЯЕМ ОЧКИ

            Player.Score += Player.Points;

            Debug.Log(Player.DestroyedCount);

            Player.Points = 0;
            Player.DestroyedCount = 0;

            Debug.Log(Player.Score);
            ScoreController.SetScore(Player.Score);
        }
    }

}
