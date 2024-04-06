using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        // �ٴ� ����
        Main.Resource.InstantiatePrefab(Define.PrefabName.floor);

        // ���̽�ƽ ����
        Main.Resource.InstantiatePrefab(Define.PrefabName.joystick);

        // �÷��̾� ����
        Main.Resource.InstantiatePrefab(Define.PrefabName.stickmanPlayer);
        
        // �� ����
        Main.Spawn.InitIntantiateEnemy(50, Define.PrefabName.stickmanEnemy);

        // ���� ����
        Main.Spawn.InitIntantiateFood(100, Define.PrefabName.food);

        return true;
    }

    


}
