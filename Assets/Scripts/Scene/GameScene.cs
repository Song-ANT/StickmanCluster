using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        Main.Save.Save();

        Main.Pool.Clear();
        Main.Stickman.ClearStickmanData();

        // 페이드 인
        Main.Resource.InstantiatePrefab("FadeInOut");

        // 바닥 생성
        Main.Resource.InstantiatePrefab(Define.PrefabName.Floor);

        // 조이스틱 생성
        Main.Resource.InstantiatePrefab(Define.PrefabName.Joystick);

        // 플레이어 생성
        Main.Spawn.InitInstantiatePlayer(Define.PrefabName.StickmanPlayer);

        // 적 생성
        Main.Spawn.InitInstantiateEnemy(30, Define.PrefabName.StickmanEnemy);

        // 음식 생성
        var foodParent = Main.Resource.InstantiatePrefab("FoodParent");
        Main.Spawn.InitInstantiateFood(200, null, foodParent.transform);

        // 게임 씬 UI 생성
        Main.UI.SetSceneUI<GameSceneUI>();

        // 게임 씬 BGM 생성
        Main.Audio.BgmPlay(Main.Resource.Load<AudioClip>(Define.Audio_BGM.Game), 0.2f);

        return true;
    }



}
