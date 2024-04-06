using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        // 官蹿 积己
        Main.Resource.InstantiatePrefab(Define.PrefabName.floor);

        // 炼捞胶平 积己
        Main.Resource.InstantiatePrefab(Define.PrefabName.joystick);

        // 敲饭捞绢 积己
        Main.Resource.InstantiatePrefab(Define.PrefabName.stickmanPlayer);
        
        // 利 积己
        Main.Spawn.InitIntantiateEnemy(50, Define.PrefabName.stickmanEnemy);

        // 澜侥 积己
        Main.Spawn.InitIntantiateFood(100, Define.PrefabName.food);

        return true;
    }

    


}
