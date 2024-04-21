using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_FoodLevel : Upgrade_Base, IUpgrade
{
    protected override void Start()
    {
        _initData = Main.Player.PlayerFoodLevel;

        base.Start();
    }


    protected override void SetPlayerActionMethod()
    {
        base.SetPlayerActionMethod();

        _initData += 1;
        Main.Player.SetPlayerFoodLevel(_initData);
    }

}
