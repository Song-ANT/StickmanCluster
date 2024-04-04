using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickmanController : MonoBehaviour
{

    private Rigidbody rb;
    private float _distance = 0.5f;
    private float _radius = 1f;
    private float _moveSpeed = 5f;
    public bool _isRun;

    private List<GameObject> _stickmans = new List<GameObject>();
    private List<Rigidbody> _stickmanRotates = new List<Rigidbody>();

    

    #region Init
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        MakeStickman(1);
        
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

    private void FixedUpdate()
    {
        MoveStickman();
    }
    #endregion




    public void MakeStickman(int num)
    {
        for (int i = 0; i < num; i++)
        {
            var temp = Main.Resource.InstantiatePrefab(Define.PrefabName.stickman, transform, true);
            _stickmans.Add(temp);
            _stickmanRotates.Add(temp.GetComponent<Rigidbody>());
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

    private void MoveStickman()
    {
        var joyVec = new Vector3(JoyStick.Instance.joyVec.x, 0, JoyStick.Instance.joyVec.y);
        var move = transform.position + joyVec;


        if (joyVec == Vector3.zero)
        {
            _isRun = false;
            return;
        }

        _isRun = true;

        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, move.x, Time.deltaTime * _moveSpeed),
            0,
            Mathf.Lerp(transform.position.z, move.z, Time.deltaTime * _moveSpeed));

        for(int i=0; i< _stickmanRotates.Count; i++)
        {
            if (joyVec != Vector3.zero)
            {
                _stickmanRotates[i].velocity = Vector3.zero;
                Quaternion newRotation = Quaternion.LookRotation(joyVec);
                _stickmanRotates[i].MoveRotation(newRotation);
            }
            
        }
    }



    
}
