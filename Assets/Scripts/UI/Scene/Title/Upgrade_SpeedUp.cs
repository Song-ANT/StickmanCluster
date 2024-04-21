using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_SpeedUp : Upgrade_Base, IUpgrade
{
    protected override void Start()
    {
        _initData = (int)(Main.Player.PlayerMoveSpeed * 10);

        base.Start();
    }


    protected override void SetPlayerActionMethod()
    {
        base.SetPlayerActionMethod();

        _initData += 1;
        Main.Player.SetPlayerMoveSpeed(_initData / 10f);
    }



    protected override void SetUpgradeLevel()
    {
        _upgrade_Level = _initData - 49;
    }

}
