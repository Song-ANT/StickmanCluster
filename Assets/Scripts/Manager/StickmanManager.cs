using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StickmanData
{
    public int index;
    public Transform rootStickman;
    public string name;
    public int count;

    public GameObject head_parts = null;
    public GameObject top_parts = null;
    public GameObject bottom_parts = null;

    public bool isPlayer;

}


public class StickmanManager 
{
    private int index = 0;
   

    public List<StickmanData> _stickmanData = new List<StickmanData>();

    
    public StickmanData AddStickmanData(Transform stickman, int count, string name = null)
    {
        StickmanData data = new StickmanData();
        data.index = index++;

        data.rootStickman = stickman;
        data.count = count;
        data.name = name != null ? name : index.ToString();

        return data;
    }


    public void SetStickmanParts(StickmanData data, GameObject part)
    {
        if (part.layer != LayerMask.NameToLayer("StickmanModel")) return;
        
        if(part.CompareTag("Parts_Head")) data.head_parts = part;
        else if(part.CompareTag("Parts_Top")) data.top_parts = part;
        else if(part.CompareTag("Parts_Bottom")) data.bottom_parts = part;
    }
}

