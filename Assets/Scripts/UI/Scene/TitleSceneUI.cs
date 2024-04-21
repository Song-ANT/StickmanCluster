using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneUI : UI_Scene
{
    public Button startBtn;
    public TextMeshProUGUI goldText;

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        SetGoldText();

        Main.Resource.InstantiatePrefab("Stickman_Shop");
        Main.Resource.InstantiatePrefab("TitleShopCamera");

        OnStartBtnClicked();

        return true;
    }

    private void OnStartBtnClicked()
    {
        startBtn.onClick.AddListener(GameStart);
    }

    private void GameStart()
    {
        SceneManager.LoadScene(Define.SceneName.Game);
    }

    private void SetGoldText()
    {
        goldText.text = Main.Player.PlayerGold.ToString();
    }
}
