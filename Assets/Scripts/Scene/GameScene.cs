using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        Main.Pool.Clear();

        // �ٴ� ����
        Main.Resource.InstantiatePrefab(Define.PrefabName.floor);

        // ���̽�ƽ ����
        Main.Resource.InstantiatePrefab(Define.PrefabName.joystick);

        // �÷��̾� ����
        Main.Spawn.InitInstantiatePlayer(Define.PrefabName.stickmanPlayer);

        // �� ����
        Main.Spawn.InitInstantiateEnemy(2, Define.PrefabName.stickmanEnemy);

        // ���� ����
        Main.Spawn.InitInstantiateFood(100, Define.PrefabName.food);

        return true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)) 
        {
            Main.Cinemachine.PlusCameraDistanceStart();
        }
    }


}
