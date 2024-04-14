using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ScrollSceneUI_Shop : MonoBehaviour
{
    public Image[] shops;
    public GameObject[] shopObject;
    private GameObject curObject;

    private List<GameObject> stickmanParts = new List<GameObject>();

    public List<GameObject> parts_Head = new List<GameObject>();
    public List<GameObject> parts_Top = new List<GameObject>();
    public List<GameObject> parts_Bottom = new List<GameObject>();

    private void Start()
    {
        curObject = shopObject[0];
        curObject.SetActive(true);

        Main.Resource.InstantiatePrefab("Stickman_Shop");
        Main.Resource.InstantiatePrefab("TitleShopCamera");


        //for(int i = 1; i< 10; i++)
        //{
        //    Instantiate(Main.Spawn.stickman_Head_Parts[i], new Vector3(i*2, 0, 5), Quaternion.identity);
        //    Instantiate(Main.Spawn.stickman_Top_Parts[i], new Vector3(i * 2, 0, 10), Quaternion.identity);
        //    Instantiate(Main.Spawn.stickman_Bottom_Parts[i], new Vector3(i * 2, 0, 15), Quaternion.identity);
        //}
    }

    public void SelectShop(int i)
    {
        curObject.SetActive(false);
        shopObject[i].SetActive(true);
        curObject = shopObject[i];
    }



}
