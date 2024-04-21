using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_FoodLevel : MonoBehaviour, IUpgrade
{
    private string[] _kmb = new string[4] { "", "K", "M", "B" };
    private int _foodLevel;
    private int _upgrade_Level = 0;
    private int _price = 0;

    public Button foodLevel_Btn;
    public TextMeshProUGUI foodLevel_GoldText;
    public TextMeshProUGUI foodLevel_LevelText;

    private void Start()
    {
        _foodLevel = Main.Player.PlayerFoodLevel;

        SetUpgradeLevel();
        SetText();
    }



    public void OnButtenClicked()
    {
        foodLevel_Btn.onClick.AddListener(Upgrade);
    }

    public void Upgrade()
    {
        if (_upgrade_Level >= 999) return;
        if (!Main.Player.GoldMinus(_price)) return;

        _foodLevel += 1;
        Main.Player.SetPlayerFoodLevel(_foodLevel);

        SetUpgradeLevel();
        SetText();
    }


    private void SetUpgradeLevel()
    {
        _upgrade_Level = _foodLevel;
    }


    private void SetText()
    {
        foodLevel_LevelText.text = "Lv. " + _upgrade_Level.ToString();
        SetPrice();
        foodLevel_GoldText.text = PriceString();
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
