using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScene : BaseScene
{
    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        Main.Pool.Clear();

        // �ٴ� ����
        Main.Resource.InstantiatePrefab(Define.PrefabName.Floor);

        // ���̽�ƽ ����
        Main.Resource.InstantiatePrefab(Define.PrefabName.Joystick);
        JoyStick.Instance.Drop();

        // �÷��̾� ����
        Main.Spawn.InitInstantiatePlayer(30, Define.PrefabName.StickmanPlayer);

        // �� ����
        Main.Spawn.InitInstantiateBoss(Define.PrefabName.StickmanEnemy);



        return true;
    }

    
}
