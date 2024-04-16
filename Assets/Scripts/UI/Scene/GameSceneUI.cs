using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneUI : UI_Scene
{
    public TextMeshProUGUI Timer;

    public TextMeshProUGUI BossLv;

    public TextMeshProUGUI Rank1Name;
    public TextMeshProUGUI Rank1Lv;

    public TextMeshProUGUI Rank2Name;
    public TextMeshProUGUI Rank2Lv;

    public TextMeshProUGUI Rank3Name;
    public TextMeshProUGUI Rank3Lv;

    public TextMeshProUGUI Rank4Name;
    public TextMeshProUGUI Rank4Lv;

    private float _currentTime;
    private float _startTime;

    private bool _isGameOver;


    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        _currentTime = Time.time;
        _startTime = Define.StartTime;
        BossLv.text = Main.Game.BossLv.ToString();
        _isGameOver = false;

        return true;
    }

    private void Update()
    {
        float timeLeft = _startTime - (Time.time - _currentTime);
        if (timeLeft < 0)
        {
            Timer.text = "00:00";
            if (!_isGameOver)
            {
                //Main.UI.SetSceneUI<GameOverSceneUI>();
                SceneManager.LoadScene(Define.SceneName.Boss);
                _isGameOver = true;
            }
            return;
        }

        string minutes = ((int)timeLeft / 60).ToString("D2");
        string seconds = ((int)(timeLeft % 60)).ToString("D2");
        Timer.text = minutes + ":" + seconds;

        UpdateTopSnakesUI();
    }


    private void UpdateTopSnakesUI()
    {
        // 상위 4개의 뱀 데이터 가져오기
        List<StickmanData> topStickman = Main.Stickman.GetTopStickman(4);

        // 가져온 데이터를 UI에 표시
        if (topStickman.Count > 0)
        {
            Rank1Name.text = topStickman[0].name;
            Rank1Lv.text = topStickman[0].level.ToString();
        }
        if (topStickman.Count > 1)
        {
            Rank2Name.text = topStickman[1].name;
            Rank2Lv.text = topStickman[1].level.ToString();
        }
        if (topStickman.Count > 2)
        {
            Rank3Name.text = topStickman[2].name;
            Rank3Lv.text = topStickman[2].level.ToString();
        }
        if (topStickman.Count > 3)
        {
            Rank4Name.text = topStickman[3].name;
            Rank4Lv.text = topStickman[3].level.ToString();
        }
    }
}
