using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _time = 0;
    private Boolean _isStopped = true;

    // Update is called once per frame
    void Update()
    {
        if (!_isStopped) _time += Time.deltaTime;
    }

    public String GetTime()
    {
        int time = (int)_time;
        int seconds = time % 60;
        int minutes = time / 60;

        return $"{minutes.ToString("00")}:{seconds.ToString("00")}";
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
