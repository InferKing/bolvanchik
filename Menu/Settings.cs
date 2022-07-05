using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Settings
{
    private string filepath = $"{Application.dataPath}/settings.dat";
    private string JsonString;
    public void SaveJson(DataSettings data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        JsonString = JsonConvert.SerializeObject(data);
        FileStream fs = File.Open(filepath,FileMode.Create);
        bf.Serialize(fs, JsonString);
        fs.Close();
    }
    public DataSettings LoadJson()
    {
        if (File.Exists(filepath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = File.Open(filepath, FileMode.Open);
            JsonString = (string)bf.Deserialize(fs);
            return JsonConvert.DeserializeObject<DataSettings>(JsonString);
        }
        else
        {
            DataSettings data = new DataSettings();
            data.isSound = true;
            JsonString = JsonConvert.SerializeObject(data);
            return data;
        }
    }
}

public class DataSettings
{
    public bool isSound;
    public DataSettings()
    {
        isSound = SoundManager.isSound;
    }
}
