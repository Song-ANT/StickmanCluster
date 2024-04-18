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


    public StickmanData AddPlayerStickmanData()
    {
        var data = Main.Stickman.AddStickmanData(playerData.level, playerData.name);
        Main.Stickman.SetStickmanParts(data, playerData.head_parts);
        Main.Stickman.SetStickmanParts(data, playerData.top_parts);
        Main.Stickman.SetStickmanParts(data, playerData.bottom_parts);

        return playerData;
    }

    public void ModifyPlayerLv(int lv)
    {
        playerData.level = lv;
    }

    public void SetPlayerColor(Color color)
    {
        playerColor = color;
    }
}
