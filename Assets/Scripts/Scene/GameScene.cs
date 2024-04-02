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

        // 플레이어 생성
        Main.Resource.InstantiatePrefab(Define.PrefabName.stickmanPlayer);
        Main.Resource.InstantiatePrefab(Define.PrefabName.stickmanEnemy);

        return true;
    }

    


}
