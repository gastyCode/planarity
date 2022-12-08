using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// A class that is used to control the UI as a singleton.
/// </summary>
public class UIController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI movesText;
    public TextMeshProUGUI timeText;

    [HideInInspector]public int score;
    [HideInInspector]public int moves;
    [HideInInspector]public String time = "00:00";

    public Timer timer;
    
    public static UIController Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    /// <summary>
    /// Update the score, moves, and time text
    /// </summary>
    void Update()
    {
        scoreText.text = score.ToString();
        movesText.text = moves.ToString();
        timeText.text = timer.GetTime();
    }

    public void Reset()
    {
        score = 0;
        moves = 0;
        timer.ResetTimer();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// It returns the time that the timer is currently at
    /// </summary>
    /// <returns>
    /// The time that the timer is currently at.
    /// </returns>
    public string GetTime()
    {
        return timer.GetTime();
    }
    
    /// <summary>
    /// This function returns the current time as an array of integers
    /// </summary>
    /// <returns>
    /// An array of integers.
    /// </returns>
    public int[] GetIntTime()
    {
        return timer.GetIntTime();
    }
}
