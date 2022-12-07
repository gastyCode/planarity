using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreSystem
{
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
