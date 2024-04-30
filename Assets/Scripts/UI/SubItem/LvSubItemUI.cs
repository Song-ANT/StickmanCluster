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

    public void SetLvPos(float size)
    {
        var x = gameObject.transform.position.x;
        var z = gameObject.transform.position.z;

        gameObject.transform.position = new Vector3 (x, size + 2, z);
        gameObject.transform.localScale = new Vector3(size, size, size);
    }
}
