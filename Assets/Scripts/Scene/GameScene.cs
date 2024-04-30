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


        // 官蹿 积己
        Main.Resource.InstantiatePrefab(Define.PrefabName.Floor);

        // 炼捞胶平 积己
        Main.Resource.InstantiatePrefab(Define.PrefabName.Joystick);

        // 敲饭捞绢 积己
        Main.Spawn.InitInstantiatePlayer(Define.PrefabName.StickmanPlayer);

        // 利 积己
        Main.Spawn.InitInstantiateEnemy(30, Define.PrefabName.StickmanEnemy);

        // 澜侥 积己
        var foodParent = Main.Resource.InstantiatePrefab("FoodParent");
        Main.Spawn.InitInstantiateFood(200, null, foodParent.transform);

        // 霸烙 纠 UI 积己
        Main.UI.SetSceneUI<GameSceneUI>();

        // 霸烙 纠 BGM 积己
        Main.Audio.BgmPlay(Main.Resource.Load<AudioClip>(Define.Audio_BGM.Game), 0.2f);

        return true;
    }



}
