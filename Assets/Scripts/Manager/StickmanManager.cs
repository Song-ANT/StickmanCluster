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

    public bool isPlayer;

}


public class StickmanManager 
{
    private int index = 0;
   

    List<StickmanData> _stickmanData = new List<StickmanData>();

    
    public StickmanData AddStickmanData(Transform stickman, int count, string name = null)
    {
        StickmanData data = new StickmanData();
        data.index = index++;

        data.rootStickman = stickman;
        data.count = count;
        data.name = name != null ? name : index.ToString();

        return data;
    }

}

