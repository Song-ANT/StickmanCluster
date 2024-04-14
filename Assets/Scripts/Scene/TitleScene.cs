using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;

        //Main.UI.SetSceneUI<TitleSceneUI>();
        Main.UI.SetSceneUI<ScrollSceneUI>();

        Main.Resource.InstantiatePrefab("Stickman_Shop");
        Main.Resource.InstantiatePrefab("TitleShopCamera");

        return true;
    }
}
