using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StickmanData
{
    public int index;
    public string name;
    public int level;
    public int initLevel = 1;
    public int foodLevel;

    public GameObject head_parts = null;
    public GameObject top_parts = null;
    public GameObject bottom_parts = null;


    public bool isPlayer;

}


public class StickmanManager 
{
    private int index = 0;
   

    public List<StickmanData> stickmanData = new List<StickmanData>();

    
    public void ClearStickmanData()
    {
        index = 0;
        stickmanData.Clear();
    }

    public StickmanData AddStickmanData(int count, int initCount, int foodLevel, string name = null)
    {
        StickmanData data = new StickmanData();
        data.index = index++;

        data.level = count;
        data.initLevel = initCount;
        data.foodLevel = foodLevel;
        data.name = name != null ? name : index.ToString();

        stickmanData.Add(data);
        return data;
    }

    public void ModifyStickmanData(StickmanData newData)
    {
        var prevData = stickmanData[newData.index];
        prevData.name = newData.name;
        prevData.level = newData.level;
    }

    public StickmanData GetStickmanData(int index)
    {
        return stickmanData[index];
    }

    public void SetStickmanParts(StickmanData data, GameObject part)
    {
        if (part == null || part.layer != LayerMask.NameToLayer("StickmanModel")) return;
        
        if(part.CompareTag("Parts_Head")) data.head_parts = part;
        else if(part.CompareTag("Parts_Top")) data.top_parts = part;
        else if(part.CompareTag("Parts_Bottom")) data.bottom_parts = part;
    }


    public List<StickmanData> GetTopStickman(int count)
    {
        // snakeDatas 리스트를 level이 높은 순으로 정렬
        List<StickmanData> sortedStickman = new List<StickmanData>(stickmanData);
        sortedStickman.Sort((x, y) => y.level.CompareTo(x.level)); // 내림차순 정렬
        

        // 상위 count개의 SnakeData를 반환
        return sortedStickman.GetRange(0, Mathf.Min(count, sortedStickman.Count));
    }

    public int GetRank(StickmanData data)
    {
        List<StickmanData> sortedStickman = new List<StickmanData>(stickmanData);
        sortedStickman.Sort((x, y) => y.level.CompareTo(x.level)); // 내림차순 정렬

        return sortedStickman.IndexOf(data) + 1;
    }

}

