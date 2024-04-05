using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman_Player_Movement : MonoBehaviour
{

    private Animator _animator;
    private Rigidbody _rb;
    private bool _isRunParameter;
    private float _moveSpeed = 5f;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MoveStickman();
    }

    private void MoveStickman()
    {
        var joyVec = new Vector3(JoyStick.Instance.joyVec.x, 0, JoyStick.Instance.joyVec.y);


        if (joyVec != Vector3.zero)
        {
            if (!_isRunParameter)
            {
                _animator.SetBool("IsRun", true);
                _isRunParameter = true;
            }
            _rb.velocity = joyVec * _moveSpeed;
            Quaternion newRotation = Quaternion.LookRotation(joyVec);
            _rb.MoveRotation(newRotation);
        }
        else
        {
            if (_isRunParameter)
            {
                _animator.SetBool("IsRun", false);
                _isRunParameter = false;
            }
        }
    }
}
