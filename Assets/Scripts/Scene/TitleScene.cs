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
    //    GameObject prefab = Instantiate(fbxModel); // FBX 모델 인스턴스화
    //    string prefabPath = "Assets/Prefabs/NewOutfit.prefab";
    //    PrefabUtility.SaveAsPrefabAsset(prefab, prefabPath); // 프리팹 저장
    //    Destroy(prefab); // 씬에서 인스턴스 제거
    //}
}
