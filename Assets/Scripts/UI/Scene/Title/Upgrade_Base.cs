using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Upgrade_Base : MonoBehaviour, IUpgrade
{
    private string[] _kmb = new string[4] { "", "K", "M", "B" };
    protected int _initData;
    protected int _upgrade_Level = 0;
    protected int _price = 0;

    [SerializeField] protected Button Btn;
    [SerializeField] protected TextMeshProUGUI GoldText;
    [SerializeField] protected TextMeshProUGUI LevelText;

    protected virtual void Start()
    {
        

        SetUpgradeLevel();
        SetText();
    }



    public void OnButtenClicked()
    {
        Btn.onClick.AddListener(Upgrade);
    }

    public void Upgrade()
    {
        if (_upgrade_Level >= 999) return;
        if (!Main.Player.GoldMinus(_price)) return;

        
        SetPlayerActionMethod();

        SetUpgradeLevel();
        SetText();
    }


    protected virtual void SetPlayerActionMethod()
    {

    }


    protected virtual void SetUpgradeLevel()
    {
        _upgrade_Level = _initData;
    }


    private void SetText()
    {
        LevelText.text = "Lv. " + _upgrade_Level.ToString();
        SetPrice();
        GoldText.text = PriceString();
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
