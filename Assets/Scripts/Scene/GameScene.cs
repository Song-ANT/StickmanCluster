using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
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

        // �÷��̾� ����
        Main.Spawn.InitInstantiatePlayer(Define.PrefabName.StickmanPlayer);

        // �� ����
        Main.Spawn.InitInstantiateEnemy(10, Define.PrefabName.StickmanEnemy);

        // ���� ����
        Main.Spawn.InitInstantiateFood(100, Define.PrefabName.Food);

        // ���� �� UI ����
        Main.UI.SetSceneUI<GameSceneUI>();

        return true;
    }



}
