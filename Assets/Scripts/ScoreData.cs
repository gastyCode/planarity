using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// A container class that stores the score, moves, and time of a game.
/// </summary>
[System.Serializable]
public class ScoreData
{
    public int Score { get; private set; }
    public int Moves { get; private set; }
    public String Time { get; private set; }
    public int[] IntTime { get; private set; }
    
    public ScoreData()
    {
        Score = 0;
        Moves = 0;
        Time = "00:00";
    }
    
    public ScoreData(UIController uiController)
    {
        Score = uiController.score;
        Moves = uiController.moves;
        Time = uiController.GetTime();
        IntTime = uiController.GetIntTime();
    }

    /// <summary>
    /// Compare two ScoreData types and returns the greater one.
    /// </summary>
    /// <param name="ScoreData">The score data to compare to.</param>
    /// <returns>
    /// The score data that is better.
    /// </returns>
    public ScoreData Compare(ScoreData compareData)
    {
        if (Score > compareData.Score)
        {
            return this;
        }
        else if (Score == compareData.Score)
        {
            if (IntTime[0] == compareData.IntTime[0] && IntTime[1] < compareData.IntTime[1])
            {
                return this;
            }
            else if (IntTime[0] < compareData.IntTime[0])
            {
                return this;
            }
            else
            {
                return compareData;
            }
        }
        else
        {
            return compareData;
        }
    }
}
