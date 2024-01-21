using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // Data becomes accessabile for saving

// Struct is a data structure
public struct Scores
{
    public int[] score {  get; set; }
    public int[] highScore;

    public void SetScore(int player, int points)
    {
        if (score == null) score = new int[2];
        score[player] = points;

        if (highScore == null) highScore = new int[2];
        if (highScore[player] < score[player])
        {
            highScore[player] = score[player];
        }
    }
}
