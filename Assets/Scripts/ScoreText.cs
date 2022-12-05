using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    public int level;
    
    private TextMeshProUGUI _text;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = DataToText(ScoreSystem.LoadData(level));
    }

    public String DataToText(ScoreData data)
    {
        return $"{data.Score} intersections with {data.Moves} moves in {data.Time}";
    }
}
