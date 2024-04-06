using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman_Enemy_Controller : StickmanController
{
    private Vector3 moveDirection;
    private BTRunner _btRunner = null;

    private float _detectOtherStickmanRange = 10f;
    private float _detectFoodRange = 15f;
    private float _moveSpeed = 5f;
    
    private bool _isRandomMoved = false;
    private bool _isPursuitOtherSnake = false;
    
    private Transform _detectStickman = null;
    private Transform _detectFood = null;

    private StickmanController _otherStickmanController;

    private Transform _otherStickman;


    protected override void Awake()
    {
        base.Awake();
        _btRunner = new BTRunner(SettingBT());
    }

    

    private void Start()
    {
        moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
    }

    private void Update()
    {
        _btRunner.operate();
        MoveStickman();
    }

    private INode SettingBT()
    {
        return new SelectorNode
            (
                new List<INode>()
                {
                    new SequenceNode
                    (
                        new List<INode>()
                        {
                            new ActionNode(CheckDetectOtherStickman),
                            new ActionNode(MoveToEatOtherStickman)
                        }
                    ),
                    new SequenceNode
                    (
                        new List<INode>()
                        {
                            new ActionNode(CheckDetectFood),
                            new ActionNode(MoveToEatFood)
                        }
                    ),
                    new ActionNode(MoveRandom)
                }
            );
    }

    private void MoveStickman()
    {
        var move = transform.position + moveDirection;


        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, move.x, Time.deltaTime * _moveSpeed),
            0,
            Mathf.Lerp(transform.position.z, move.z, Time.deltaTime * _moveSpeed));

        for (int i = 0; i < _stickmanChilds.Count; i++)
        {
            if (moveDirection != Vector3.zero)
            {
                _stickmanChilds[i].rb.velocity = Vector3.zero;
                //Quaternion newRotation = Quaternion.LookRotation(moveDirection);
                //_stickmanChilds[i].rb.MoveRotation(newRotation);

                _stickmanChilds[i].transform.rotation = Quaternion.LookRotation(moveDirection);

                _stickmanChilds[i].SetRunAnimation();
            }
            else _stickmanChilds[i].SetIdleAnimation();
        }
    }


    #region Detect & Move Node
    private INode.ENodeState CheckDetectOtherStickman()
    {
        if (_otherStickman != null) return INode.ENodeState.ESuccess;

        if (_isPursuitOtherSnake) return INode.ENodeState.EFailure;

        var overlapColliders = Physics.OverlapSphere(transform.position, _detectOtherStickmanRange, LayerMask.GetMask("Stickman"));
        if (overlapColliders != null && overlapColliders.Length > 0)
        {
            foreach (var collider in overlapColliders)
            {
                if (!collider.CompareTag("Head")) continue;
                _detectStickman = collider.transform;
                _otherStickmanController = _detectStickman.transform.GetComponent<StickmanController>();

                if (_otherStickmanController.GetLevel() < _level)
                {
                    _otherStickman = _detectStickman;
                    StartCoroutine(DetectOtherStickmanTime());
                    return INode.ENodeState.ESuccess;
                }
            }
        }

        _detectStickman = null;
        _otherStickmanController = null;
        _otherStickman = null;

        return INode.ENodeState.EFailure;
    }

    private IEnumerator DetectOtherStickmanTime()
    {
        yield return new WaitForSeconds(4f);
        _otherStickman = null;
        StartCoroutine(CoolDownDetectOtherStickman());
    }

    private IEnumerator CoolDownDetectOtherStickman()
    {
        _isPursuitOtherSnake = true;
        yield return new WaitForSeconds(4f);
        _isPursuitOtherSnake = false;
    }


    private INode.ENodeState MoveToEatOtherStickman()
    {
        if (_otherStickman != null)
        {
            moveDirection = (_otherStickman.position - transform.position).normalized;
            if (Vector3.Distance(_otherStickman.position, transform.position) < 0.5f)
            {
                _otherStickman = null;
                return INode.ENodeState.ESuccess;
            }
            return INode.ENodeState.ERunning;
        }

        return INode.ENodeState.EFailure;
    }
    #endregion


    #region Food
    private INode.ENodeState CheckDetectFood()
    {
        //if(_otherSnakeHead != null) return INode.ENodeState.EFailure;
        if (_detectFood != null) return INode.ENodeState.ESuccess;

        var overlapColliders = Physics.OverlapSphere(transform.position, _detectOtherStickmanRange, LayerMask.GetMask("Food"));
        if (overlapColliders != null && overlapColliders.Length > 0)
        {
            _detectFood = overlapColliders[0].transform;

            return INode.ENodeState.ESuccess;
        }

        _detectFood = null;

        return INode.ENodeState.EFailure;
    }

    private INode.ENodeState MoveToEatFood()
    {
        if (_detectFood != null)
        {
            moveDirection = (_detectFood.position - transform.position).normalized;
            if (Vector3.Distance(_detectFood.position, transform.position) < 0.5f)
            {
                _detectFood = null;
                return INode.ENodeState.ESuccess;
            }
            return INode.ENodeState.ERunning;
        }

        return INode.ENodeState.EFailure;
    }
    #endregion




    #region MoveRandom
    private INode.ENodeState MoveRandom()
    {
        if (!_isRandomMoved)
        {
            _isRandomMoved = true;
            moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            StartCoroutine(IsRandomMoved());
            return INode.ENodeState.ESuccess;
        }

        return INode.ENodeState.EFailure;
    }

    private IEnumerator IsRandomMoved()
    {
        yield return new WaitForSeconds(2f);
        _isRandomMoved = false;
    }
    #endregion




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _detectOtherStickmanRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _detectFoodRange);
    }
}
