
using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CinemachineManager 
{
    private Transform _player;
    private CinemachineVirtualCamera _playerCamera;

    public event Action OnCameraDistanceEvent;

    public void SetPlayerStickmanCamera(Transform player)
    {
        _player = player;
        var playerCameraObject = Main.Resource.InstantiatePrefab(Define.PrefabName.playerCamera);
        _playerCamera = playerCameraObject.GetComponent<CinemachineVirtualCamera>();
        var playerStickmanCamera = _playerCamera.GetComponent<PlayerStickmanCamera>();
        playerStickmanCamera.Initialized(player);
    }

    public void PlusCameraDistanceStart()
    {
        OnCameraDistanceEvent?.Invoke();
    }
}
