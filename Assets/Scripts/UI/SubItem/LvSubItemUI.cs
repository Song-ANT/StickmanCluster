using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LvSubItemUI : UI_Base
{
    public TextMeshProUGUI LvText;

    public override bool Initialize()
    {
        if (!base.Initialize()) return false;



        return true;
    }


    public void SetLvText(int level)
    {
        LvText.text = level.ToString();
    }
}
