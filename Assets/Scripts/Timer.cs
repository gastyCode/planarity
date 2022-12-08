using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that serves as a timer.
/// </summary>
public class Timer : MonoBehaviour
{
    private float _time = 0;
    private Boolean _isStopped = true;

    // Update is called once per frame
    void Update()
    {
        if (!_isStopped) _time += Time.deltaTime;
    }

    /// <summary>
    /// It takes the time in seconds, converts it to minutes and seconds, and returns it as a string
    /// </summary>
    /// <returns>
    /// A string with the format "00:00"
    /// </returns>
    public String GetTime()
    {
        int time = (int)_time;
        int seconds = time % 60;
        int minutes = time / 60;

        return $"{minutes.ToString("00")}:{seconds.ToString("00")}";
    }

    /// <summary>
    /// It takes the time in seconds, converts it to minutes and seconds, and returns an array of integers
    /// </summary>
    /// <returns>
    /// An array of integers.
    /// </returns>
    public int[] GetIntTime()
    {
        int time = (int)_time;
        int seconds = time % 60;
        int minutes = time / 60;

        return new int[] {minutes, seconds};
    }
    
    public void ResetTimer()
    {
        _time = 0;
    }

    public void Run()
    {
        _isStopped = false;
    }

    public void Stop()
    {
        _isStopped = true;
    }
}
