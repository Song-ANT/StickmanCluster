using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverSceneUI : UI_Scene
{
    //public TextMeshProUGUI resultLv;

    public Button restartBtn;
    public Button mainmenuBtn;
    public TextMeshProUGUI clearGoldText;
    public TextMeshProUGUI rankingText;
    public TextMeshProUGUI levelText;

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        Time.timeScale = 0.001f;

        //resultLv.text = Main.Stickman.GetSnakeData(0).level.ToString();
        SetClearGoldText();
        SetRankinText();
        SetLevelText();

        restartBtn.onClick.AddListener(RestartBtnClicked);
        mainmenuBtn.onClick.AddListener(MainmenuBtnClicked);


        return true;
    }

    private void RestartBtnClicked()
    {
        SceneManager.LoadScene(Define.SceneName.Game);
    }

    private void MainmenuBtnClicked()
    {
        SceneManager.LoadScene(Define.SceneName.Title);
    }

    public void SetClearGoldText()
    {
        //clearGoldText.text = clearGold.ToString();
        clearGoldText.text = Main.Game.ClearGold.ToString();
    }

    public void SetRankinText()
    {
        int rank = Main.Player.GameRank;
        string unit = Define.RankingUnit(rank);

        rankingText.text = rank + unit;
    }

    

    public void SetLevelText()
    {
        int level = Main.Player.GameLevel;
        levelText.text = level == 0 ? "Die" : level.ToString();
    }
}
