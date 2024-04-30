using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CandyCoded.HapticFeedback;

public class Stickman : MonoBehaviour
{
    private StickmanController _controller;
    private Animator _animator;
    private bool _isRunParameter;
    public bool _isEated;
    private int _rootCode;
    private bool _ismakeMove = false;
    
    [HideInInspector] public Rigidbody rb;
    public GameObject body;


    private void Awake()
    {
        //_animator = transform.GetComponent<Animator>();
        _animator = transform.GetComponentInChildren<Animator>();
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
        _isEated = false;

        //body.GetComponent<SkinnedMeshRenderer>().material.color = _controller.GetColor();
        body.GetComponent<SkinnedMeshRenderer>().material.color = _controller.GetColor(this);

    }

    


    private void OnTriggerEnter(Collider other)
    {
        if (_ismakeMove) return;

        if(other.gameObject.layer == LayerMask.NameToLayer("Food"))
        {
            _controller.MakeStickman(EatFoodMakeStickmanCount());
            other.GetComponent<Stickman_Food>().Eated();
            if(_controller._isPlayer) HapticFeedback.LightFeedback();
        }

        if(other.gameObject.layer == LayerMask.NameToLayer("Stickman"))
        {
            if (other.transform.root.GetHashCode() == _rootCode) return;
            if (!other.TryGetComponent<Stickman>(out Stickman otherStickman)) return;
            if (otherStickman._isEated) return;
            if (!other.transform.root.TryGetComponent<StickmanController>(out StickmanController otherController)) return;
            if (Time.timeScale < 1) return;


            if(otherController == null || _controller == null) return;
            else if (otherController?.GetLevel() < _controller?.GetLevel())
            {
                _controller.MakeStickman(1);
                if(_controller._isPlayer) HapticFeedback.MediumFeedback();
            }
            else
            {
                Main.Audio.SfxPlay(Main.Resource.Load<AudioClip>(Define.Audio_SFX.StickmanEat), _controller.transform, 0.6f);
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
        if(_isEated) return;
        _isEated = true;
        if (_controller._isPlayer) HapticFeedback.MediumFeedback();
        SetIdleAnimation();
        RemoveFromList();
        _controller.SetLevel(false);
        _controller.FormatStickman();
        _controller = null;

        Main.Pool.Push(gameObject, true);
    }

    public void RemoveFromList()
    {
        // StickmanController를 통해 리스트에서 이 인스턴스를 제거
        _controller?.RemoveStickman(this.gameObject, this);
    }

    public void SetStickmanColor(Color color)
    {
        body.GetComponent<SkinnedMeshRenderer>().material.color = color;
    }

    public int EatFoodMakeStickmanCount()
    {
        //if (_controller._isPlayer) return Main.Player.playerData.foodLevel;
        //else return 1;
        return _controller.FoodLevel;
    }

    public void SetMakeMove(bool isMakeMove)
    {
        _ismakeMove = isMakeMove;
    }

    

}
