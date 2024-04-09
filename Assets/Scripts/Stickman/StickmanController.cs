using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public abstract class StickmanController : MonoBehaviour
{
    protected int _level;

    private float _distance = 0.5f;
    private float _radius = 1f;
    private bool _isPlayer;


    private List<GameObject> _stickmans = new List<GameObject>();
    protected List<Stickman> _stickmanChilds = new List<Stickman>();


    private Color _color;


    #region Init
    protected virtual void Awake()
    {
        _isPlayer = gameObject.CompareTag("Player");
        SetColor();
        MakeStickman(1);
        _level = 1;
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
            _level++;
        }

        FormatStickman();
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

            if (Vector3.Distance(child.transform.position, transform.position + newPos) > _distance)
            {
                child.position = transform.position;
            }

            child.DOLocalMove(newPos, 1f).SetEase(Ease.OutBack);
        }
    }


    public int GetLevel()
    {
        return _level;
    }

    public void SetLevel(int num)
    {
        _level += num;
        
    }



    public void SetColor()
    {
        float colorX = Random.Range(0, 1f);
        float colory = Random.Range(0, 1f);
        float colorz = Random.Range(0, 1f);
        _color = _isPlayer ? Color.blue : new Color(colorX, colory, colorz);
        
    }

    public Color GetColor() => _color;


    public void RemoveStickman(GameObject stickmanObject, Stickman stickman)
    {
        if (_stickmanChilds.Contains(stickman))
        {
            _stickmans.Remove(stickmanObject);
            _stickmanChilds.Remove(stickman);
            
            if (_stickmanChilds.Count == 0) AllStickmanDie();
        }
    }

    private void AllStickmanDie()
    {
        if (_isPlayer)
        {
            Main.Pool.Clear();
            Main.UI.SetSceneUI<GameOverSceneUI>();
        }
        Destroy(gameObject);
        
    }

}

