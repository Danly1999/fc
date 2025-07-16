using Godot;
using System;
using System.IO;
using System.Text.Json;

public class GameManager
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }
    public PlayerData playerData = new PlayerData();

    // 保存到JSON
    public void SaveToJson(string path)
    {
        var data = playerData;
        ResourceSaver.Save(data, path);
        //string json = JsonSerializer.Serialize(data);
        //File.WriteAllText(path, json);
    }

    // 从JSON读取
    public void LoadFromJson(string path)
    {
        if (!File.Exists(path)) return;
        //string json = File.ReadAllText(path);
        //var data = JsonSerializer.Deserialize<PlayerData>(json);
        var data = ResourceLoader.Load<PlayerData>(path);
        if (data != null)
        {
            playerData.DataLoad(data);
        }
    }

}
