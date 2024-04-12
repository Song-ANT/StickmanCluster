using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleScrollController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Scrollbar scrollbar;

    private const int Size = 3;
    private float[] pos = new float[Size];
    private float distance;
    private float targetPos;
    private float curPos;
    private int targetIndex;
    private bool isDrag;
    private bool isStart;


    public void Initialize()
    {
        distance = 1f / (Size - 1f);
        for (int i = 0; i < Size; i++) pos[i] = distance * i;

        targetIndex = 1;
        scrollbar.value = pos[1];
        targetPos = pos[1];
    }


    private void Update()
    {
        if (!isStart)
        {
            scrollbar.value = pos[1];
            isStart = true;
            return;
        }

        if (!isDrag) scrollbar.value = Mathf.Lerp(scrollbar.value, targetPos, 0.1f);
    }
        

    public void OnBeginDrag(PointerEventData eventData)
    {
        curPos = SetPos();
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDrag = true;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        targetPos = SetPos();


        if(curPos == targetPos)
        {

            if(eventData.delta.x > 10 && curPos - distance >= 0)
            {
                --targetIndex;
                targetPos = curPos - distance;
            }

            else if(eventData.delta.x < -10 && curPos - distance < 1.01f) 
            {
                ++targetIndex;
                targetPos = curPos + distance;
            }
        }
    }


    private float SetPos()
    {
        for (int i = 0; i < Size; i++)
        {
            if (scrollbar.value < pos[i] + distance * 0.5f && scrollbar.value > pos[i] - distance * 0.5f)
            {
                targetIndex = i;
                return pos[i];
            }
        }

        return 0;
    }
}
