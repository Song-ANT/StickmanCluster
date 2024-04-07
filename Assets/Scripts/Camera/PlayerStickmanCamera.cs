using Cinemachine;
using Cinemachine.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStickmanCamera : MonoBehaviour
{
    private Transform followTarget;
    private Vector3 offset;
    private Vector3 lookDirection;

    private CinemachineVirtualCamera _camera;


    public void Initialized(Transform player)
    {
        followTarget = player;
        offset = new Vector3(0, 10, -10);
        //lookDirection = new Vector3(-50, 0, 0);
        _camera = transform.GetComponent<CinemachineVirtualCamera>();
        _camera.LookAt = player;


        Main.Cinemachine.OnCameraDistanceEvent -= PlusDistanceCamera;
        Main.Cinemachine.OnCameraDistanceEvent += PlusDistanceCamera;
    }


    private void OnDestroy()
    {
        Main.Cinemachine.OnCameraDistanceEvent -= PlusDistanceCamera;
    }


    private void LateUpdate()
    {
        if (followTarget == null) return;

        transform.position = followTarget.position + offset; // 카메라 위치 조정
        //transform.rotation = Quaternion.LookRotation(lookDirection); // 카메라 회전 고정

        
    }



    public void PlusDistanceCamera()
    {
        Debug.Log("커져라");
        //_camera.m_Lens.FieldOfView += 10;

        Vector3 cameraDirection = this.transform.localRotation * Vector3.forward;
        offset -= cameraDirection;
    }
}
