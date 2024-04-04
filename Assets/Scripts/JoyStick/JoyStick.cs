using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour
{
    private static JoyStick instance;


    public static JoyStick Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<JoyStick>();
                if(instance == null) 
                {
                    var instanceContanier = new GameObject("JoyStick");
                    instance = instanceContanier.AddComponent<JoyStick>();
                }
            }
            return instance;
        }
    }

    public GameObject smallStick;
    public GameObject BGStick;
    private Vector3 stickFirstPosition;
    public Vector3 joyVec;
    private float stickRadius;

    private void Start()
    {
        stickRadius = BGStick.gameObject.GetComponent<RectTransform>().sizeDelta.y ;
    }


    #region Event
    public void PointDown()
    {
        BGStick.gameObject.SetActive(true);
        BGStick.transform.position = Input.mousePosition;
        smallStick.transform.position = Input.mousePosition;

        stickFirstPosition = Input.mousePosition;
        //Todo : 애니메이션 걷는 모션으로 바꾸기
    }

    public void Drag(BaseEventData baseEventData)
    {
        PointerEventData pointerEventData = baseEventData as PointerEventData;
        Vector3 DragPosition = pointerEventData.position;
        joyVec = (DragPosition - stickFirstPosition).normalized;
        
        float stickDistance = Vector3.Distance(stickFirstPosition, DragPosition);

        if (stickDistance < stickRadius)
        {
            smallStick.transform.position = stickFirstPosition + joyVec * stickDistance;
        }
        else
        {
            smallStick.transform.position = stickFirstPosition + joyVec * stickRadius;
        }
    }

    public void Drop()
    {
        BGStick.gameObject.SetActive(false);
        joyVec = Vector3.zero;
        //Todo : 애니메이션 아이들 상태로 바꾸기 
    }

    #endregion





}
