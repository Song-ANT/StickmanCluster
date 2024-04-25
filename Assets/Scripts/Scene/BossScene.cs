using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScene : BaseScene
{
    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        Main.Pool.Clear();
        Main.Stickman.ClearStickmanData();

        // 官蹿 积己
        Main.Resource.InstantiatePrefab(Define.PrefabName.Floor);

        // 炼捞胶平 积己
        Main.Resource.InstantiatePrefab(Define.PrefabName.Joystick);
        JoyStick.Instance.Drop();

        // 敲饭捞绢 积己
        //Main.Spawn.InitInstantiatePlayer(30, Define.PrefabName.StickmanPlayer);
        Main.Spawn.InitInstantiatePlayer(Define.PrefabName.StickmanPlayer);

        // 利 积己
        Main.Spawn.InitInstantiateBoss(Define.PrefabName.StickmanBoss);

        // 霸烙 纠 BGM 积己
        Main.Audio.BgmPlay(Main.Resource.Load<AudioClip>(Define.Audio_BGM.Game), 0.2f);

        return true;
    }

    
}
