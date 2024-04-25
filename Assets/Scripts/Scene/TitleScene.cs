using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TitleScene : BaseScene
{

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        Main.UI.SetSceneUI<TitleSceneUI>();
        Main.Save.Save();

        //Main.UI.SetSceneUI<ScrollSceneUI>();

        // �ٴ� ����
        Main.Resource.InstantiatePrefab(Define.PrefabName.Floor);

        // �÷��̾� ����
        var stickman = Main.Resource.InstantiatePrefab(Define.PrefabName.Stickman);
        Main.Cinemachine.SetPlayerStickmanCamera(stickman.transform);


        Main.Audio.BgmPlay(Main.Resource.Load<AudioClip>(Define.Audio_BGM.Title), 0.2f);

        //CreatePrefabFromFBX(Main.Resource.Load<GameObject>("Stickman-Model"));

        return true;
    }

    //public void CreatePrefabFromFBX(GameObject fbxModel)
    //{
    //    GameObject prefab = Instantiate(fbxModel); // FBX �� �ν��Ͻ�ȭ
    //    string prefabPath = "Assets/Prefabs/NewOutfit.prefab";
    //    PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath); // ������ ����
    //    Destroy(prefab); // ������ �ν��Ͻ� ����
    //}
}
