using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScene : BaseScene
{
    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        Main.Pool.Clear();

        // 官蹿 积己
        Main.Resource.InstantiatePrefab(Define.PrefabName.Floor);

        // 炼捞胶平 积己
        Main.Resource.InstantiatePrefab(Define.PrefabName.Joystick);
        JoyStick.Instance.Drop();

        // 敲饭捞绢 积己
        Main.Spawn.InitInstantiatePlayer(30, Define.PrefabName.StickmanPlayer);

        // 利 积己
        Main.Spawn.InitInstantiateBoss(Define.PrefabName.StickmanEnemy);



        return true;
    }

    
}
