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

        // �ٴ� ����
        Main.Resource.InstantiatePrefab(Define.PrefabName.Floor);

        // ���̽�ƽ ����
        Main.Resource.InstantiatePrefab(Define.PrefabName.Joystick);
        JoyStick.Instance.Drop();

        // �÷��̾� ����
        //Main.Spawn.InitInstantiatePlayer(30, Define.PrefabName.StickmanPlayer);
        Main.Spawn.InitInstantiatePlayer(Define.PrefabName.StickmanPlayer);

        // �� ����
        Main.Spawn.InitInstantiateBoss(Define.PrefabName.StickmanBoss);

        // ���� �� BGM ����
        Main.Audio.BgmPlay(Main.Resource.Load<AudioClip>(Define.Audio_BGM.Game), 0.2f);

        return true;
    }

    
}
