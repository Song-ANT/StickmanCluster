using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager 
{
    public StickmanData playerData = new StickmanData()
    {
        index = 0,
        name = "Player",
        initLevel = 1,
        level = 0,
        foodLevel = 1,

        head_parts = null,
        top_parts = null,
        bottom_parts = null,

        isPlayer = true
    };

    public Color playerColor;
    private int _playerGold = 0;
    private float _playerMoveSpeed = 5f;
    private int _playerMoveLevel = 1;
    private int _gameRank;
    private int _gameLevel;


    public int PlayerGold => _playerGold;
    public float PlayerMoveSpeed => _playerMoveSpeed;
    public int PlayerMoveLevel => _playerMoveLevel;
    public int GameRank => _gameRank;
    public int GameLevel => _gameLevel;
    public event Action OnGoldChangeEvent;


    #region AddStickman
    public StickmanData AddPlayerStickmanData()
    {
        var data = Main.Stickman.AddStickmanData(playerData.level, playerData.initLevel, playerData.foodLevel, playerData.name);
        Main.Stickman.SetStickmanParts(data, playerData.head_parts);
        Main.Stickman.SetStickmanParts(data, playerData.top_parts);
        Main.Stickman.SetStickmanParts(data, playerData.bottom_parts);


        return data;
    }
    #endregion


    #region Status
    public void SetPlayerSaveData(PlayerSaveData save)
    {
        playerData.index = save.index;
        playerData.name = save.name;
        playerData.level = save.level;
        playerData.initLevel = save.initLevel;
        playerData.foodLevel = save.playerFoodLevel;

        playerData.head_parts = save.head_parts;
        playerData.top_parts = save.top_parts;
        playerData.bottom_parts = save.bottom_parts;

        _playerGold = save.playerGold;
        _playerMoveSpeed = save.playerMoveSpeed;
    }

    public void ModifyPlayerLv(int lv)
    {
        playerData.level = lv;
    }

    public void ModifyPlayerInitLv(int lv)
    {
        playerData.initLevel = lv;
    }

    public void SetPlayerColor(Color color)
    {
        playerColor = color;
    }

    public void SetPlayerMoveSpeed(float speed)
    {
        _playerMoveSpeed = speed;
    }

    public void SetPlayerMoveLevel(int level)
    {
        _playerMoveLevel = level;
    }
    public void SetPlayerFoodLevel(int level)
    {
        playerData.foodLevel = level;
    }

    public void SetInitGameRankLevel()
    {
        _gameRank = 0;
        _gameLevel = 0;
    }

    public void SetGameRankLevel()
    {
        _gameRank = Main.Stickman.GetRank(Main.Stickman.GetStickmanData(0));
        _gameLevel = playerData.level;
    }
    #endregion



    #region Gold
    public void GoldPlus(int increase)
    {
        _playerGold += increase;
        OnGoldChangeEvent?.Invoke();
    }

    public bool GoldMinus(int decrease)
    {
        if(_playerGold - decrease < 0) return false;

        _playerGold -= decrease;
        OnGoldChangeEvent?.Invoke();
        return true;
    }
    #endregion
}
