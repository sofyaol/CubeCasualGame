using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player 
{
    internal static long Score { get; set; } = 0; // очки за время игры

    internal static int Points { get; set; } = 0; // очки за одну платформу
    internal static int DestroyedCount { get; set; } = 0; // кол-во уничтоженных кубиков на данный момент
}
