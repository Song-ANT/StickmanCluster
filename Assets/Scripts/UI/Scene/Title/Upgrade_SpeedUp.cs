using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_SpeedUp : MonoBehaviour, IUpgrade
{
    private string[] _kmb = new string[4] { "", "K", "M", "B" };
    private float _moveSpeed;
    private int _upgrade_Level = 0;
    private int _price = 0;

    public Button speedUp_Btn;
    public TextMeshProUGUI speedUp_GoldText;
    public TextMeshProUGUI speedUp_LevelText;

    private void Start()
    {
        _moveSpeed = Main.Player.PlayerMoveSpeed;

        SetUpgradeLevel();
        SetText();
    }

    

    public void OnButtenClicked()
    {
        speedUp_Btn.onClick.AddListener(Upgrade);
    }

    public void Upgrade()
    {
        if (_upgrade_Level >= 999) return;
        if (!Main.Player.GoldMinus(_price)) return;

        _moveSpeed += 0.1f;
        Main.Player.SetPlayerMoveSpeed(_moveSpeed);

        SetUpgradeLevel();
        SetText();
    }


    private void SetUpgradeLevel()
    {
        var plusSpeed = _moveSpeed - 5f;
        _upgrade_Level = (int)(plusSpeed / 0.1f) + 1;
    }


    private void SetText()
    {
        speedUp_LevelText.text = "Lv. " + _upgrade_Level.ToString();
        SetPrice();
        speedUp_GoldText.text = PriceString();
    }

    private void SetPrice()
    {
        _price = _upgrade_Level * 1;
    }

    private string PriceString()
    {
        int i = 0;
        float unitPrice = _price;
        
        while ((int)(unitPrice / 1000) > 0)
        {
            i++;
            unitPrice /= 1000;
        }

        return unitPrice.ToString() + _kmb[i]; 
    }
}
