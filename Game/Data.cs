using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;

public class Data
{
    private string filepath = $"{Application.dataPath}/data.dat";
    public Player loadData;
    public string JsonString;

    public void WriteJson(Player EditData)
    {
        JsonString = JsonConvert.SerializeObject(EditData);
    }

    public void RemoveData()
    {
        if (File.Exists(filepath))
        {
            File.Delete(filepath);
        }
    }
    public void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(filepath, FileMode.Create);
        bf.Serialize(file, JsonString);
        file.Close();
    }

    public void LoadData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        Debug.Log(filepath);
        if (File.Exists(filepath))
        {
            FileStream file = File.Open(filepath, FileMode.Open);
            JsonString = (string)bf.Deserialize(file);
            loadData = JsonConvert.DeserializeObject<Player>(JsonString);
            file.Close();
        }
        else
        {
            FileStream file = File.Open(filepath, FileMode.CreateNew);
            loadData = new Player();
            WriteJson(loadData);
            bf.Serialize(file, JsonString);
            file.Close();
        }
    }
}
public class Player
{
    public int BestScore { get; set; }
    public Player()
    {
        BestScore = 0;
    }
}
