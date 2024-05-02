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

        // 페이드 인
        Main.Resource.InstantiatePrefab("FadeInOut");

        // 바닥 생성
        Main.Resource.InstantiatePrefab(Define.PrefabName.Floor);

        // 조이스틱 생성
        Main.Resource.InstantiatePrefab(Define.PrefabName.Joystick);
        JoyStick.Instance.Drop();

        // 플레이어 생성
        //Main.Spawn.InitInstantiatePlayer(30, Define.PrefabName.StickmanPlayer);
        Main.Spawn.InitInstantiatePlayer(Define.PrefabName.StickmanPlayer);

        // 적 생성
        Main.Spawn.InitInstantiateBoss(Define.PrefabName.StickmanBoss);

        // 게임 씬 BGM 생성
        Main.Audio.BgmPlay(Main.Resource.Load<AudioClip>(Define.Audio_BGM.Game), 0.2f);

        return true;
    }

    
}
