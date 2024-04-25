using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_SpeedUp : Upgrade_Base, IUpgrade
{
    private float _speed;

    protected override void Start()
    {
        _initData = Main.Player.PlayerMoveLevel;
        _speed = Main.Player.PlayerMoveSpeed;

        base.Start();
    }


    protected override void SetPlayerActionMethod()
    {
        base.SetPlayerActionMethod();

        _initData += 1;
        Main.Player.SetPlayerMoveSpeed(_speed + 0.1f);
        Main.Player.SetPlayerMoveLevel(_initData);
    }




}
