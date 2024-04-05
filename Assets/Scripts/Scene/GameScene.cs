using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        // 바닥 생성
        Main.Resource.InstantiatePrefab(Define.PrefabName.floor);

        // 조이스틱 생성
        Main.Resource.InstantiatePrefab(Define.PrefabName.joystick);

        // 플레이어 생성
        Main.Resource.InstantiatePrefab(Define.PrefabName.stickmanPlayer);
        
        Main.Resource.InstantiatePrefab(Define.PrefabName.stickmanEnemy);

        // 음식 생성
        Main.Spawn.InitIntantiateFood(100, Define.PrefabName.food);

        return true;
    }

    


}
