using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    // Update is called once per frame
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

    public string GetTime()
    {
        return timer.GetTime();
    }
    
    public int[] GetIntTime()
    {
        return timer.GetIntTime();
    }
}
