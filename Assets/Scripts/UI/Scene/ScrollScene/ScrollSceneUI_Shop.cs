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

    private GameObject _modelStickman;
    private Transform _rootBorn;

    public List<GameObject> parts_Head = new List<GameObject>();
    public List<GameObject> parts_Top = new List<GameObject>();
    public List<GameObject> parts_Bottom = new List<GameObject>();

    private void Start()
    {
        curObject = shopObject[0];
        curObject.SetActive(true);

        _modelStickman = Main.Resource.InstantiatePrefab("Stickman_Shop");
        var a = Utilities.FindChildrenWithTag(_modelStickman.transform, "rootBone", true);
        _rootBorn = a[0].transform;
        

        Main.Resource.InstantiatePrefab("TitleShopCamera");

        var head = Instantiate(Main.Spawn.stickman_Head_Parts[1], _modelStickman.transform);



        Main.Spawn.UpdateSkinnedMeshRenderer(_rootBorn, head, true);




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
