using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// A class that is used to display the score of a level.
/// </summary>
public class ScoreText : MonoBehaviour
{
    public int level;
    
    private TextMeshProUGUI _text;
    
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = DataToText(ScoreSystem.LoadData(level));
    }

    /// <summary>
    /// It converts a ScoreData object into a string
    /// </summary>
    /// <param name="ScoreData">This is the data that will be displayed in the leaderboard.</param>
    /// <returns>
    /// A string with the score, moves, and time.
    /// </returns>
    private String DataToText(ScoreData data)
    {
        return $"{data.Score} intersections with {data.Moves} moves in {data.Time}";
    }
}
