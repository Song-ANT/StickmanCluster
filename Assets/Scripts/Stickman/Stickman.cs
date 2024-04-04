using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    private StickmanController _controller;
    private Animator _animator;
    private bool _isRunParameter;

    private void Start()
    {
        _controller = transform.root.GetComponent<StickmanController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        
        if (_isRunParameter == false && _controller._isRun == true)
        {
            _isRunParameter = true;
            _animator.SetBool("IsRun", true);
        }
        else if(_isRunParameter == true && _controller._isRun == false)
        {
            _isRunParameter = false;
            _animator.SetBool("IsRun", false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Food"))
        {
            Debug.Log(other.name + _controller.gameObject.name);
            _controller.MakeStickman(1);
            other.GetComponent<Stickman_Food>().Eated();
        }
    }

}
