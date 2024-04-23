using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerSaveData
{
    //public StickmanData playerData;

    public int index;
    public string name;
    public int level;
    public int initLevel = 1;

    public GameObject head_parts = null;
    public GameObject top_parts = null;
    public GameObject bottom_parts = null;


    public int playerGold;
    public float playerMoveSpeed;
    public int playerFoodLevel;

    public int BossLevel;
}


public class SaveLoadManager 
{
    private string path;

    private PlayerSaveData data;

    public void DataLoad_Player() // 파일 불러오기
    {
        data = new();

        path = PlayerDataFilePath();
        FileInfo fileInfo = new(path);

        if (fileInfo.Exists)
        {
            Load();
        }
        else
        {
            DefaltData();
            Save();
        }
    }


    private string PlayerDataFilePath()
    {
        return Path.Combine(Application.persistentDataPath + "/SaveData.json");

    }
    public void Save()
    {
        path = PlayerDataFilePath();

        SavePlayerdata();
        

        string jsonData = JsonUtility.ToJson(data, true);
        //System.IO.File.WriteAllText(path, Crypto.AESEncrypt(jsonData));
        System.IO.File.WriteAllText(path, jsonData);
    }

    private void SavePlayerdata()
    {
        data.index = Main.Player.playerData.index;
        data.name = Main.Player.playerData.name;
        data.level = Main.Player.playerData.level;
        data.initLevel = Main.Player.playerData.initLevel;

        data.top_parts = Main.Player.playerData.top_parts;
        data.bottom_parts = Main.Player.playerData.bottom_parts;
        data.head_parts = Main.Player.playerData.head_parts;

        data.playerGold = Main.Player.PlayerGold;
        data.playerMoveSpeed = Main.Player.PlayerMoveSpeed;
        data.playerFoodLevel = Main.Player.PlayerFoodLevel;

        data.BossLevel = Main.Game.BossLv;
    }

    private void Load()
    {
        path = PlayerDataFilePath();
        string jsonData = System.IO.File.ReadAllText(path);
        //string ddd = Crypto.AESDecrypt(jsonData);
        string ddd = jsonData;


        data = JsonUtility.FromJson<PlayerSaveData>(ddd);

        SetLoadData(data);
    }

    private void SetLoadData(PlayerSaveData data)
    {
        Main.Player.SetPlayerSaveData(data);
        Main.Game.BossLv = data.BossLevel;
    }


    private void DefaltData()
    {
        data.index = 0;
        data.name = "Player";
        data.level = 1;
        data.initLevel = 1;

        data.top_parts = null;
        data.bottom_parts = null;
        data.head_parts = null;

        data.playerGold = 1000;
        data.playerMoveSpeed = 5f;
        data.playerFoodLevel = 1;

        data.BossLevel = 50;
    }




}
