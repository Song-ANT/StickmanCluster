using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    public static T GetOrAddComponent<T>(GameObject go) where T : Component
    {
        return go.GetComponent<T>() ?? go.AddComponent<T>();
    }


    public static List<GameObject> FindChildrenWithTag(Transform parent, string tag, bool includeInactive = false)
    {
        List<GameObject> taggedChildren = new List<GameObject>();
        RecursiveFindWithTag(parent, tag, taggedChildren, includeInactive);
        return taggedChildren;
    }

    private static void RecursiveFindWithTag(Transform parent, string tag, List<GameObject> taggedChildren, bool includeInactive)
    {
        foreach (Transform child in parent)
        {
            if (!child.gameObject.activeSelf && !includeInactive)
                continue;

            if (child.CompareTag(tag))
            {
                taggedChildren.Add(child.gameObject);
            }

            // ¿Á±Õ »£√‚
            RecursiveFindWithTag(child, tag, taggedChildren, includeInactive);
        }
    }

}
