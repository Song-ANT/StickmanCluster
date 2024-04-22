using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager 
{
    public Dictionary<int, GameObject> stickman_Head_Parts = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> stickman_Top_Parts = new Dictionary<int, GameObject>();
    public Dictionary<int, GameObject> stickman_Bottom_Parts = new Dictionary<int, GameObject>();


    // 플레이어 소환 - 초기레벨 1일경우
    public void InitInstantiatePlayer(string initObject)
    {
        var player = Main.Resource.InstantiatePrefab(initObject);
        Main.Cinemachine.SetPlayerStickmanCamera(player.transform);

        var initCamera = Main.Player.playerData.initLevel / 10;
        for (int i = 0; i < initCamera; i++)
        {
            Debug.Log(i);
            Main.Cinemachine.CameraDistanceStart(true);
        }
    }

    // 플레이어 소환 - 초기레벨 initCount의 경우
    public void InitInstantiatePlayer(int initCount, string initObject)
    {
        var player = Main.Resource.InstantiatePrefab(initObject);
        Main.Cinemachine.SetPlayerStickmanCamera(player.transform);

        StickmanController controller = player.GetComponent<StickmanController>();
        controller.MakeStickman(initCount - 1);
    }


    // 보스 소환
    public void InitInstantiateBoss(string initObject)
    {
        var Boss = Main.Resource.InstantiatePrefab(initObject);

        Boss.transform.position = new Vector3(0, 0, 30);
        Boss.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

        //StickmanController controller = Boss.GetComponent<StickmanController>();
        //controller.MakeStickman(Main.Game.BossLv - 1);
    }

    // 적 소환
    public void InitInstantiateEnemy(int initCount, string initObject)
    {
        for (int i = 0; i < initCount; i++)
        {
            float x = Random.Range(-50f, 50f);
            float y = Random.Range(-50f, 50f);
            Vector3 pos = new Vector3(x, 0.5f, y);
            GameObject enemy = Main.Resource.InstantiatePrefab(initObject, pos, Quaternion.identity);
        }
    }


    // 중립 스틱맨 소환
    public void InitInstantiateFood(int initCount, string initObject = null, Transform parent = null)
    {
        for (int i = 0; i < initCount; i++)
        {
            float x = Random.Range(-50f, 50f);
            float y = Random.Range(-180f, 180f);
            float z = Random.Range(-50f, 50f);

            Vector3 pos = new Vector3(x, 0, z);
            Quaternion rot = Quaternion.Euler(new Vector3(0, y, 0));

            string objectName = initObject == null ? Define.FoodPrefabName() : initObject;
            GameObject food = Main.Resource.InstantiatePrefab(objectName, pos, rot, parent, true);

            food.transform.position = pos;
            food.transform.rotation = rot;
        }
    }

    


    // 스틱맨 부분 파츠 리스트에 추가
    public void InitializeStickmanParts()
    {
        for (int i = 0; i < 9; i++)
        {
            stickman_Head_Parts.Add(i+1, Main.Resource.Load<GameObject>($"Head_{i+1}"));
            stickman_Bottom_Parts.Add(i + 1, Main.Resource.Load<GameObject>($"Bottom_{i + 1}"));
            stickman_Top_Parts.Add(i + 1, Main.Resource.Load<GameObject>($"Top_{i + 1}"));
        }
    }


    // 스틱맨 스킨 변경
    public void UpdateSkinnedMeshRenderer(Transform rootBone, GameObject targetSkinObject, bool includeInactive)
    {
        if (!targetSkinObject.TryGetComponent<SkinnedMeshRenderer>(out SkinnedMeshRenderer targetSkin) || rootBone == null)
        {
            //Debug.Log("TargetSkin or RootBone is not set.");
            return;
        }

        

        Transform[] newBones = new Transform[targetSkin.bones.Length];
        Transform[] existingBones = rootBone.GetComponentsInChildren<Transform>(includeInactive);
        for (int i = 0; i < targetSkin.bones.Length; i++)
        {
            Transform foundBone = System.Array.Find(existingBones, bone => bone.name == targetSkin.bones[i].name);
            if (foundBone != null)
            {
                newBones[i] = foundBone;
            }
            else
            {
                //Debug.Log("Bone " + targetSkin.bones[i].name + " not found!");
            }
        }
        targetSkin.bones = newBones;
        //Debug.Log("Skinned Mesh Renderer updated.");
    }
}
