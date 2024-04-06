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


    private List<GameObject> _stickmans = new List<GameObject>();
    protected List<Stickman> _stickmanChilds = new List<Stickman>();


    private Color _color;
    

    #region Init
    protected virtual void Awake()
    {
        SetColor();
        MakeStickman(1);
        _level = 1;
    }

    private void Update()
    {
        if(transform.root.name == "StickmanPlayer" && Input.GetKeyDown(KeyCode.I)) 
        {
            MakeStickman(1); 
        }

        if(transform.root.name != "StickmanPlayer" && Input.GetKeyDown(KeyCode.O))
        {
            MakeStickman(1);
        }

        

    }

    
    #endregion




    public void MakeStickman(int num)
    {
        for (int i = 0; i < num; i++)
        {
            var temp = Main.Resource.InstantiatePrefab(Define.PrefabName.stickman, transform, true);
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
            //_distance = Random.Range(0.5f, 1f);
            //_radius = Random.Range(0.5f, 1f);

            var x = _distance * Mathf.Sqrt(i) * Mathf.Cos(i * _radius);
            var y = _distance * Mathf.Sqrt(i) * Mathf.Sin(i * _radius);

            var newPos = new Vector3(x, 0, y);

            //var child = transform.GetChild(i);
            var child = _stickmans[i].transform;

            if (Vector3.Distance(child.localPosition, newPos) > _distance)
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
        _color = gameObject.CompareTag("Player") ? Color.blue : new Color(colorX, colory, colorz);
        
    }

    public Color GetColor() => _color;


    public void RemoveStickman(Stickman stickman)
    {
        if (_stickmanChilds.Contains(stickman))
        {
            _stickmanChilds.Remove(stickman);
            if(_stickmanChilds.Count == 0) AllStickmanDie();
        }
    }

    private void AllStickmanDie()
    {
        Destroy(gameObject);
    }

}

