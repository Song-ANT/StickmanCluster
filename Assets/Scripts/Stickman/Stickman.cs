using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    private StickmanController _controller;
    private Animator _animator;
    private bool _isRunParameter;

    public Rigidbody rb;

    private void Start()
    {
        _controller = transform.root.GetComponent<StickmanController>();
        _animator = transform.GetComponent<Animator>();
        rb = transform.GetComponent<Rigidbody>();
    }

    


    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Food"))
        {
            _controller.MakeStickman(1);
            other.GetComponent<Stickman_Food>().Eated();
        }
    }

    public void SetRunAnimation()
    {
        if (_isRunParameter) return;
        _isRunParameter = true;
        _animator.SetBool("IsRun", true);
    }

    public void SetIdleAnimation()
    {
        if (!_isRunParameter) return;
        _isRunParameter = false;
        _animator.SetBool("IsRun", false);
    }

}
