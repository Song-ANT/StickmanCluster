using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneUI : UI_Scene
{
    public TextMeshProUGUI Timer;

    public TextMeshProUGUI BossLv;

    public TextMeshProUGUI Rank1Lv;
    public TextMeshProUGUI Rank2Lv;
    public TextMeshProUGUI Rank3Lv;

    public GameObject TimeOver;
    private TextMeshProUGUI _timeOver_Text;
    private bool _isTimeOver;
    public GameObject GameOver;


    public GameObject[] PlayerRankIcon;

    private GameObject curRankIcon;


    private float _currentTime;
    private float _startTime;

    private bool _isGameOver;

    private FadeInOut _fadeInOut;
    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        _currentTime = Time.time;
        _startTime = Define.StartTime;
        BossLv.text = Main.Game.BossLv.ToString();
        _isGameOver = false;
        _fadeInOut = FindObjectOfType<FadeInOut>();
        _timeOver_Text = TimeOver.GetComponent<TextMeshProUGUI>();
        


        return true;
    }

    private void Update()
    {
        float timeLeft = _startTime - (Time.time - _currentTime);
        if(!_isTimeOver && timeLeft < 6) 
        {
            _isTimeOver = true;
            TimeOver.SetActive(true);
        }
        if (timeLeft < 0)
        {
            Timer.text = "00:00";
            if (!_isGameOver)
            {
                //Main.UI.SetSceneUI<GameOverSceneUI>();
                Main.Player.SetGameRankLevel();
                //SceneManager.LoadScene(Define.SceneName.Boss);
                StartCoroutine(_fadeInOut.ChangeScene(Define.SceneName.Boss));
                _isGameOver = true;

                TimeOver.SetActive(false);
                GameOver.SetActive(true);
            }
            return;
        }

        string minutes = ((int)timeLeft / 60).ToString("D2");
        string seconds = ((int)(timeLeft % 60)).ToString("D2");
        Timer.text = minutes + ":" + seconds;
        if(_isTimeOver) _timeOver_Text.text = minutes + ":" + seconds;

        UpdateTopSnakesUI();
    }


    private void UpdateTopSnakesUI()
    {
        // 상위 4개의 스틱맨 데이터 가져오기
        List<StickmanData> topStickman = Main.Stickman.GetTopStickman(3);

        int playerRank = -1;
        for(int i = 0; i< topStickman.Count; i++)
        {
            if (topStickman[i].index == 0) playerRank = i;
        }

        SetPlayerRankIcon(playerRank);



        // 가져온 데이터를 UI에 표시
        if (topStickman.Count > 0)
        {
            //Rank1Name.text = topStickman[0].name;
            Rank1Lv.text = topStickman[0].level.ToString();
        }
        if (topStickman.Count > 1)
        {
            //Rank2Name.text = topStickman[1].name;
            Rank2Lv.text = topStickman[1].level.ToString();
        }
        if (topStickman.Count > 2)
        {
            //Rank3Name.text = topStickman[2].name;
            Rank3Lv.text = topStickman[2].level.ToString();
        }
        //if (topStickman.Count > 3)
        //{
        //    //Rank4Name.text = topStickman[3].name;
        //    Rank4Lv.text = topStickman[3].level.ToString();
        //}
    }


    private void SetPlayerRankIcon(int i)
    {
        if(curRankIcon != null) curRankIcon.SetActive(false);
        if(i != -1)
        {
            PlayerRankIcon[i].SetActive(true);
            curRankIcon = PlayerRankIcon[i];
        }
    }
    
    
}
