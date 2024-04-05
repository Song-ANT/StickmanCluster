using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickmanController : MonoBehaviour
{

    private float _distance = 0.5f;
    private float _radius = 1f;
    private bool _isPlayer;

    private List<GameObject> _stickmans = new List<GameObject>();
    private List<Stickman> _childStickmans = new List<Stickman>();

    

    #region Init
    private void Awake()
    {
        _isPlayer = gameObject.layer == LayerMask.NameToLayer("Player");
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
    #endregion




    public void MakeStickman(int num)
    {
        for (int i = 0; i < num; i++)
        {
            var temp = Main.Resource.InstantiatePrefab(Define.PrefabName.stickman, transform, true);
            _stickmans.Add(temp);
            _childStickmans.Add(temp.GetComponent<Stickman>());

            if(_isPlayer) temp.AddComponent<Stickman_Player_Movement>();
            // Todo: Àû add component;
        }

        FormatStickman();
    }

    public void FormatStickman()
    {

        for (int i = 0; i < _stickmans.Count; i++)
        {
            //_distance = Random.Range(0.5f, 1f);
            //_radius = Random.Range(0.5f, 1f);

            var x = _stickmans[0].transform.position.x + _distance * Mathf.Sqrt(i) * Mathf.Cos(i * _radius);
            var y = _stickmans[0].transform.position.z + _distance * Mathf.Sqrt(i) * Mathf.Sin(i * _radius);

            var newPos = new Vector3(x, 0, y);

            var child = _stickmans[i].transform;

            //if (Vector3.Distance(child.localPosition, newPos) > _distance)
            //{
            //    child.position = transform.position;
            //}

            //if (Vector3.Distance(_stickmans[0].transform.position, newPos) > _distance)
            //{
            //    child.position = _stickmans[0].transform.position;
            //}

            //child.DOLocalMove(newPos, 1f).SetEase(Ease.OutBack);
            child.position = newPos;
        }
    }

    //private void MoveStickman()
    //{
    //    var joyVec = new Vector3(JoyStick.Instance.joyVec.x, 0, JoyStick.Instance.joyVec.y);
    //    var move = transform.position + joyVec;


    //    if (joyVec == Vector3.zero)
    //    {
    //        _isRun = false;
    //        return;
    //    }

    //    _isRun = true;

    //    transform.position = new Vector3(
    //        Mathf.Lerp(transform.position.x, move.x, Time.deltaTime * _moveSpeed),
    //        0,
    //        Mathf.Lerp(transform.position.z, move.z, Time.deltaTime * _moveSpeed));

    //    for(int i=0; i< _stickmanRotates.Count; i++)
    //    {
    //        if (joyVec != Vector3.zero)
    //        {
    //            _stickmanRotates[i].velocity = Vector3.zero;
    //            Quaternion newRotation = Quaternion.LookRotation(joyVec);
    //            _stickmanRotates[i].MoveRotation(newRotation);
    //        }
            
    //    }
    //}



    
}
