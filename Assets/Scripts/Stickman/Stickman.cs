using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    private StickmanController _controller;
    private Animator _animator;
    private bool _isRunParameter;
    private int _rootCode;
    
    [HideInInspector] public Rigidbody rb;
    public GameObject body;


    private void Awake()
    {
        _animator = transform.GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }

    public void Initialize()
    {
        _controller = transform.root.GetComponent<StickmanController>();
        _animator.enabled = true;
        rb = transform.GetComponent<Rigidbody>();
        _rootCode = transform.root.GetHashCode();

        body.GetComponent<SkinnedMeshRenderer>().material.color = _controller.GetColor();

    }

    


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Food"))
        {
            _controller.MakeStickman(1);
            other.GetComponent<Stickman_Food>().Eated();
        }

        if(other.gameObject.layer == LayerMask.NameToLayer("Stickman"))
        {
            if (other.transform.root.GetHashCode() == _rootCode) return;
            if (!other.transform.root.TryGetComponent<StickmanController>(out StickmanController otherController)) return;

            if(otherController.GetLevel() < _controller.GetLevel())
            {
                _controller.MakeStickman(1);
            }
            else
            {
                Eated();
            }
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

    public void Eated()
    {
        SetIdleAnimation();
        RemoveFromList();
        _controller.SetLevel(-1);
        _controller.FormatStickman();
        _controller = null;

        Main.Pool.Push(gameObject, true);
    }

    public void RemoveFromList()
    {
        // StickmanController를 통해 리스트에서 이 인스턴스를 제거
        _controller?.RemoveStickman(this.gameObject, this);
    }

}
