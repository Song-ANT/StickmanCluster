using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LockOnCamera : MonoBehaviour
{
    private Transform _target;
    // dhod
    private void Awake()
    {
        _target = Camera.main.transform;
        var dir = _target.forward;
        transform.rotation = Quaternion.LookRotation(dir);
    }

    private void Update()
    {
        var dir = _target.forward;
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
