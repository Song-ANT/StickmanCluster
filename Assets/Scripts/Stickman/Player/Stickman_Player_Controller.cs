using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stickman_Player_Controller : StickmanController
{
    
    private float _moveSpeed ;

    protected override void Awake()
    {
        base.Awake();
        _moveSpeed = Main.Player.PlayerMoveSpeed;
    }

    private void Update()
    {
        MoveStickman();
    }


    private void FixedUpdate()
    {
        RotateStickman();
    }

    private void MoveStickman()
    {
        var joyVec = new Vector3(JoyStick.Instance.joyVec.x, 0, JoyStick.Instance.joyVec.y);
        var move = transform.position + joyVec;

        bool isBossScene = SceneManager.GetActiveScene().name.Equals(Define.SceneName.Boss);
        if (isBossScene) move = transform.position + transform.forward;

        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, move.x, Time.deltaTime * _moveSpeed),
            0,
            Mathf.Lerp(transform.position.z, move.z, Time.deltaTime * _moveSpeed));

        
    }

    private void RotateStickman()
    {
        var joyVec = new Vector3(JoyStick.Instance.joyVec.x, 0, JoyStick.Instance.joyVec.y);
        bool isBossScene = SceneManager.GetActiveScene().name.Equals(Define.SceneName.Boss);

        for (int i = 0; i < _stickmanChilds.Count; i++)
        {
            if (isBossScene) { _stickmanChilds[i].SetRunAnimation(); continue; }
            if (joyVec != Vector3.zero)
            {
                _stickmanChilds[i].rb.velocity = Vector3.zero;
                Quaternion newRotation = Quaternion.LookRotation(joyVec);
                _stickmanChilds[i].rb.MoveRotation(newRotation);

                _stickmanChilds[i].SetRunAnimation();
            }
            else _stickmanChilds[i].SetIdleAnimation();

        }
    }

    

}
