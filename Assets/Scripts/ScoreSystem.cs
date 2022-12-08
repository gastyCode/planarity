using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// A class that is used to save and load data.
/// </summary>
public class ScoreSystem
{
    /// <summary>
    /// It creates a new file in the persistent data path of the application, and saves the data to it
    /// </summary>
    /// <param name="uiController">The UIController class that holds the score and time data.</param>
    public static void SaveData(UIController uiController)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        String path = Application.persistentDataPath + $"/data{CurrentLevel.Instance.GetLevel()}.bin";

        ScoreData data = new ScoreData(UIController.Instance);
        
        if (File.Exists(path))
        {
            ScoreData savedData = ScoreSystem.LoadData();
            
            data = data.Compare(savedData);
        }
        
        FileStream file = new FileStream(path, FileMode.Create);
        
        formatter.Serialize(file, data);
        file.Close();
    }

    /// <summary>
    /// If the file exists, open it, deserialize it, and return the data. If the file doesn't exist, return a new ScoreData
    /// object
    /// </summary>
    /// <param name="level">The level you want to load the data from.</param>
    /// <returns>
    /// A ScoreData object
    /// </returns>
    public static ScoreData LoadData(int level)
    {
        String path = Application.persistentDataPath + $"/data{level}.bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(file) as ScoreData;
            file.Close();

            return data;
        }
        else
        {
            return new ScoreData();
        }
    }
    
    /// <summary>
    /// If the file exists, open it, deserialize it, and return the data. If the file doesn't exist, create a new ScoreData
    /// object and return it
    /// </summary>
    /// <returns>
    /// A ScoreData object from current level.
    /// </returns>
    private static ScoreData LoadData()
    {
        String path = Application.persistentDataPath + $"/data{CurrentLevel.Instance.GetLevel()}.bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            ScoreData data = formatter.Deserialize(file) as ScoreData;
            file.Close();

            return data;
        }
        else
        {
            return new ScoreData();
        }
    }
}
