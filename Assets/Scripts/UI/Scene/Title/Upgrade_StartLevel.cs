using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade_StartLevel : MonoBehaviour, IUpgrade
{
    private string[] _kmb = new string[4] {"", "K", "M", "B" };
    private int _initLevel;
    private int _price = 0;

    public Button startLevel_Btn;
    public TextMeshProUGUI startLevel_GoldText;
    public TextMeshProUGUI startLevel_LevelText;

    private void Start()
    {
        _initLevel = Main.Player.playerData.initLevel;
        SetText();
    }



    public void OnButtenClicked()
    {
        startLevel_Btn.onClick.AddListener(Upgrade);
    }

    public void Upgrade()
    {
        if (_initLevel >= 999) return;
        if (!Main.Player.GoldMinus(_price)) return;

        _initLevel++;
        Main.Player.ModifyPlayerInitLv(_initLevel);

        SetText();
    }


    private void SetText()
    {
        startLevel_LevelText.text = "Lv. " + _initLevel.ToString();
        SetPrice();
        startLevel_GoldText.text = PriceString();
    }


    private void SetPrice()
    {
        _price = _initLevel * 1;
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
