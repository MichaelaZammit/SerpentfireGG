using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SaveData
{
    private static string filePath = Application.persistentDataPath + "/Scores.json";
    public static void Save(Scores scoreData)
    {
        string data = JsonUtility.ToJson(scoreData);
        File.WriteAllText(filePath, data);
    }

    public static Scores Load()
    {
        // file does not exist, so stop here
        if (!File.Exists(filePath)) 
        { 
            return new Scores();
        }

        string data = File.ReadAllText(filePath);
        Scores scoreData = JsonUtility.FromJson<Scores>(data);
        return scoreData;
    }

}
