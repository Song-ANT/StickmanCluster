using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public abstract class StickmanController : MonoBehaviour
{
    private StickmanData _data;
    protected int _level ;
    private int _initLevel;
    private LvSubItemUI _lvUI;

    private float _distance = 0.5f;
    private float _radius = 1f;
    public bool _isPlayer;


    private List<GameObject> _stickmans = new List<GameObject>();
    protected List<Stickman> _stickmanChilds = new List<Stickman>();


    private Color _color;


    #region Init
    protected virtual void Awake()
    {
        _isPlayer = gameObject.CompareTag(Define.TagName.Player);
        _lvUI = Main.UI.SetSubItemUI<LvSubItemUI>(this.transform);
        _color = SetColor();
        if (_isPlayer) Main.Player.SetPlayerColor(_color);

        InitializeData();
        ConfigureInitialStickman();
    }

    private void InitializeData()
    {
        if (_isPlayer)
        {
            _data = Main.Player.AddPlayerStickmanData();
        }
        else
        {
            _initLevel = GetInitialLevel();
            _data = Main.Stickman.AddStickmanData(_initLevel, _initLevel);
        }

    }

    private int GetInitialLevel()
    {
        if (IsBossScene())
        {
            return Main.Game.BossLv;
        }
        return _initLevel == 0 ? 1 : _initLevel;
    }

    private bool IsBossScene()
    {
        return SceneManager.GetActiveScene().name.Equals(Define.SceneName.Boss);
    }

    private void ConfigureInitialStickman()
    {
        int initialLevel = IsBossScene() ? _data.level : _data.initLevel;
        MakeStickman(initialLevel);
        _level = initialLevel;
    }
    #endregion




    public void MakeStickman(int num)
    {
        for (int i = 0; i < num; i++)
        {
            var temp = Main.Resource.InstantiatePrefab(Define.PrefabName.Stickman, transform, true);
            _stickmans.Add(temp);
            var stickman = temp.GetComponent<Stickman>();
            stickman.Initialize();
            _stickmanChilds.Add(stickman);
            SetLevel(true);
        }

        
        FormatStickman(num);
    }

    public void FormatStickman()
    {

        for (int i = 0; i < _stickmans.Count; i++)
        {
            _distance = Random.Range(0.5f, 0.6f);
            _radius = Random.Range(0.9f, 1f);

            var x = _distance * Mathf.Sqrt(i) * Mathf.Cos(i * _radius);
            var y = _distance * Mathf.Sqrt(i) * Mathf.Sin(i * _radius);

            var newPos = new Vector3(x, 0, y);

            //var child = transform.GetChild(i);
            var child = _stickmans[i].transform;

            //if (Vector3.Distance(child.position, transform.position) > _distance * Mathf.Sqrt(i))
            //{
            //    child.position = transform.position;
            //}

            

            child.DOLocalMove(newPos, 1f).SetEase(Ease.OutBack);

            //child.position = newPos;
        }
    }

    public void FormatStickman(int num)
    {

        for (int i = 0; i < _stickmans.Count; i++)
        {
            _distance = Random.Range(0.5f, 0.6f);
            _radius = Random.Range(0.9f, 1f);

            var x = _distance * Mathf.Sqrt(i) * Mathf.Cos(i * _radius);
            var y = _distance * Mathf.Sqrt(i) * Mathf.Sin(i * _radius);

            var newPos = new Vector3(x, 0, y);

            //var child = transform.GetChild(i);
            var child = _stickmans[i].transform;

            //if (Vector3.Distance(child.position, transform.position) > _distance * Mathf.Sqrt(i))
            //{
            //    child.position = transform.position;
            //}

            if(i >= _stickmans.Count - num)
            {
                child.position = transform.position;
                child.DOLocalMove(newPos, 1f).SetEase(Ease.OutBack);
            }


            //child.position = newPos;
        }
    }


    public int GetLevel()
    {
        return _level;
    }

    public void SetLevel(bool isPositive)
    {
        _level += isPositive ? 1 : -1;
        

        if (_isPlayer) 
        {
            Main.Player.ModifyPlayerLv(_level);
            if(_level % 10 == 0)  Main.Cinemachine.CameraDistanceStart(isPositive);
        }
        _data.level = _level;
        Main.Stickman.ModifyStickmanData(_data);
        _lvUI.SetLvText(_level);
        
    }



    public Color SetColor()
    {
        if (IsBossScene() && _isPlayer) return Main.Player.playerColor;

        float colorX = Random.Range(0, 1f);
        float colory = Random.Range(0, 1f);
        float colorz = Random.Range(0, 1f);
        //_color = _isPlayer ? Color.blue : new Color(colorX, colory, colorz);
        return new Color(colorX, colory, colorz);
    }

    public Color GetColor() => _color;

    public Color GetColor(Stickman stickman)
    {
        if (_stickmanChilds.Count == 0 || _stickmanChilds[0] == stickman) return Color.white;
        else
        {
            if (_isPlayer) return Main.Player.playerColor;
            else return _color;
        }
    }


    public void RemoveStickman(GameObject stickmanObject, Stickman stickman)
    {
        if (_stickmanChilds.Contains(stickman))
        {
            _stickmans.Remove(stickmanObject);
            _stickmanChilds.Remove(stickman);

            if (_stickmanChilds.Count == 0) AllStickmanDie();
            else _stickmanChilds[0].SetStickmanColor(Color.white);

            InstantiateSplatEffect();
        }
    }

    private void InstantiateSplatEffect()
    {
        Vector3 splatPos = transform.position + new Vector3(Random.Range(-3f, 3f), 0.1f, Random.Range(-3f, 3f));
        Quaternion splatRot = Quaternion.Euler(new Vector3(90, 0, 0));

        GameObject obj = GameObject.FindWithTag("SplatParent");
        if (obj == null)
        {
            obj = new() { name = @"SplatParent", tag = "SplatParent" };
        }

        string splatName = Define.PrefabName.SplatEffect + Random.Range(1, 3).ToString();
        var splat = Main.Resource.InstantiatePrefab(splatName, splatPos, splatRot, obj.transform, true);
        splat.GetComponent<Splat>().SetInit(_color);
    }

    private void AllStickmanDie()
    {
        if (_isPlayer)
        {
            int clearGold = SetClearGold();
            Main.Pool.Clear();
            var gameOverUI = Main.UI.SetSceneUI<GameOverSceneUI>();
            //gameOverUI.SetClearGoldText(clearGold);
            Main.Game.SetClearGold(clearGold);
            if (!IsBossScene()) Main.Player.SetGameRankLevel();
        }
        else if (gameObject.CompareTag(Define.TagName.Boss))
        {
            int clearGold = SetClearGold();
            Main.Pool.Clear();
            var bossClearUI = Main.UI.SetSceneUI<GameOverSceneUI>();
            clearGold += (Main.Game.BossLv * 10);
            Main.Game.BossClear();
            Main.Game.SetClearGold(clearGold);
        }


        Destroy(gameObject);
        
    }

    private int SetClearGold()
    {
        int clearGold = _level;
        int rank = 10;

        var ranking = Main.Stickman.GetTopStickman(10);
        foreach ( var item in ranking )
        {
            if (item.index == _data.index) { clearGold += rank; Debug.Log("rank : " + rank); }
            rank--;
        }

        return clearGold * 10;
    }

}

