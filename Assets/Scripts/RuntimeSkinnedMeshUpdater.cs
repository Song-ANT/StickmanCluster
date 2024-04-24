using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeSkinnedMeshUpdater : MonoBehaviour
{
    public SkinnedMeshRenderer targetSkin;
    public Transform rootBone;
    public bool includeInactive;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) // U 키를 누르면 업데이트
        {
            UpdateSkinnedMeshRenderer();
        }
    }

    void UpdateSkinnedMeshRenderer()
    {
        if (targetSkin == null || rootBone == null)
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
