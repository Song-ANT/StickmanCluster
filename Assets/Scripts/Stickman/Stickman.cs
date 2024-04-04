using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman : MonoBehaviour
{
    private StickmanController _controller;

    private void Start()
    {
        _controller = transform.root.GetComponent<StickmanController>();
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
