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
        //Main.UI.SetSceneUI<ScrollSceneUI>();

        


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
