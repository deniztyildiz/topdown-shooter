using System;
using UnityEngine;

public static class ScoreManager
{
    // A static variable to hold the score. It's shared across all scripts.
    public static int enemiesKilled = 0;

    // A static event to announce when the score changes.
    public static event Action<int> OnScoreChanged;

    public static void AddKill()
    {
        enemiesKilled += 1;
        Debug.Log($"Kills: {enemiesKilled}") ;
        // Announce that the score has changed and send the new value.
        OnScoreChanged?.Invoke(enemiesKilled);
    }

    // A helper function to reset the score, e.g., when starting a new game.
    public static void ResetScore()
    {
        enemiesKilled = 0;
        OnScoreChanged?.Invoke(enemiesKilled);
    }
}