using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _time = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _time += Time.deltaTime;
        int time = (int)_time;
        int seconds = time % 60;
        int minutes = time / 60;

        String timeText = $"{minutes.ToString("00")}:{seconds.ToString("00")}";
        UIController.Instance.time = timeText;
    }
}
