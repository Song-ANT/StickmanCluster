using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneUI : UI_Scene
{
    private string[] _kmb = new string[4] { "", "K", "M", "B" };

    public Button startBtn;
    public Toggle soundBtn;
    public Upgrade_Base startLevel_Btn;
    public Upgrade_Base speedUp_Btn;
    public Upgrade_Base foodLevel_Btn;

    public Sprite sound_O_Image;
    public Sprite sound_X_Image;

    public TextMeshProUGUI goldText;


    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        Main.Player.OnGoldChangeEvent -= SetGoldText;
        Main.Player.OnGoldChangeEvent += SetGoldText;

        SetGoldText();

        //Main.Resource.InstantiatePrefab("Stickman_Shop");
        //Main.Resource.InstantiatePrefab("TitleShopCamera");

        OnBtnListener();

        return true;
    }

    private void OnBtnListener()
    {
        startBtn.onClick.AddListener(GameStart);
        soundBtn.onValueChanged.AddListener(SoundClicked);
        startLevel_Btn.OnButtenClicked();
        speedUp_Btn.OnButtenClicked();
        foodLevel_Btn.OnButtenClicked();
    }

    private void GameStart()
    {
        SceneManager.LoadScene(Define.SceneName.Game);
    }

    private void SoundClicked(bool toggle)
    {
        if (toggle)
        {
            soundBtn.GetComponent<Image>().sprite = sound_O_Image;
        }
        else
        {
            soundBtn.GetComponent<Image>().sprite = sound_X_Image;
        }
    }

    private void SetGoldText()
    {
        goldText.text = GoldString();
    }

    private string GoldString()
    {
        int i = 0;
        float gold = Main.Player.PlayerGold;

        while ((int)(gold / 1000) > 0)
        {
            i++;
            gold /= 1000;
        }

        return gold.ToString("f1") + _kmb[i];
    }
}
