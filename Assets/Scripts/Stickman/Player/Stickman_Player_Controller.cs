using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman_Player_Controller : StickmanController
{
    
    private float _moveSpeed = 5f;



    private void FixedUpdate()
    {
        MoveStickman();
    }

    private void MoveStickman()
    {
        var joyVec = new Vector3(JoyStick.Instance.joyVec.x, 0, JoyStick.Instance.joyVec.y);
        var move = transform.position + joyVec;


        transform.position = new Vector3(
            Mathf.Lerp(transform.position.x, move.x, Time.deltaTime * _moveSpeed),
            0,
            Mathf.Lerp(transform.position.z, move.z, Time.deltaTime * _moveSpeed));

        for (int i = 0; i < _stickmanChilds.Count; i++)
        {
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
