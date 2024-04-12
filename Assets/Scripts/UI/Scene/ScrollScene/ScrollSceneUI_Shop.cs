using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSceneUI_Shop : MonoBehaviour
{
    public Image[] shops;
    public GameObject[] shopObject;
    private GameObject curObject;

    private void Start()
    {
        curObject = shopObject[0];
        curObject.SetActive(true);
    }

    public void SelectShop(int i)
    {
        curObject.SetActive(false);
        shopObject[i].SetActive(true);
        curObject = shopObject[i];
    }


}
