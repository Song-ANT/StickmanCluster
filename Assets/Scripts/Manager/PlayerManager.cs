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

        head_parts = null,
        top_parts = null,
        bottom_parts = null,

        isPlayer = true
    };

    public Color playerColor;
    private int _playerGold = 1234567;
    private float _playerMoveSpeed = 5f;
    private int _playerFoodLevel = 1;



    public int PlayerGold => _playerGold;
    public float PlayerMoveSpeed => _playerMoveSpeed;
    public int PlayerFoodLevel => _playerFoodLevel;
    public event Action OnGoldChangeEvent;


    #region AddStickman
    public StickmanData AddPlayerStickmanData()
    {
        var data = Main.Stickman.AddStickmanData(playerData.level, playerData.initLevel, playerData.name);
        Main.Stickman.SetStickmanParts(data, playerData.head_parts);
        Main.Stickman.SetStickmanParts(data, playerData.top_parts);
        Main.Stickman.SetStickmanParts(data, playerData.bottom_parts);


        return data;
    }
    #endregion


    #region Status
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

    public void SetPlayerFoodLevel(int levle)
    {
        _playerFoodLevel = levle;
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
