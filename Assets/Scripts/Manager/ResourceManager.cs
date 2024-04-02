using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager 
{

    public bool Loaded = false;
    public Dictionary<string, Object> _resources = new();


    #region ReadResources ------------------------------------------------------------------------------------------
    public void ResourcesAssign()
    {
        if (Loaded) return;

        ResourcesToDictionary<GameObject>();
        //ResourcesToDictionary<InputActionAsset>();
        ResourcesToDictionary<Material>();

        

        Loaded = true;

    }

    public void ResourcesToDictionary<T>() where T : Object
    {
        foreach (var obj in Resources.LoadAll<T>(""))
        {
            if (!_resources.ContainsKey(obj.name))
                _resources.Add(obj.name, obj);
        }
    }
    #endregion



    #region Load & UnLoad--------------------------------------------------------------------------------------------
    public T Load<T>(string key) where T : Object
    {
        if (_resources.TryGetValue(key, out var resource)) return resource as T;

        return null;

    }
    public void Unload(string key)
    {
        if (_resources.TryGetValue(key, out var resource))
        {
            _resources.Remove(key);
            Resources.UnloadAsset(resource); 
        }
    }
    #endregion



    #region Instatiate Prefab ---------------------------------------------------------------------------------------
    public GameObject InstantiatePrefab(string key, Transform parent = null, bool pooling = false)
    {
        GameObject prefab = Load<GameObject>(key);

        if (prefab == null)
        {
            Debug.LogError($"{key}프리팹 불러오기 실패");
            return null;
        }

        if (pooling)
        {
            GameObject poo = Main.Pool.Pop(prefab);
            poo.transform.parent = parent;
            return poo;
        }

        GameObject obj = GameObject.Instantiate(prefab, parent);
        obj.name = prefab.name;
        return obj;
    }

    public GameObject InstantiatePrefab(string key, Vector3 _position, Quaternion _rotate, bool pooling = false)
    {
        GameObject prefab = Load<GameObject>(key);

        if (prefab == null)
        {
            // Debug.LogError($"{key}프리팹 불러오기 실패"); 
            return null;
        }

        if (pooling) // Todo : 잘 작동하는지 확인하기
        {
            GameObject temp = Main.Pool.Pop(prefab);
            temp.transform.position = _position;
            temp.transform.rotation = _rotate;

            return temp; 
        }

        GameObject obj = GameObject.Instantiate(prefab, _position, _rotate);
        obj.name = prefab.name;
        return obj;
    }

    public void Destroy(GameObject obj) //프리팹 풀로돌리기 풀없으면 삭제
    {
        if (obj == null) return;
        if (Main.Pool.Push(obj)) return;

        UnityEngine.Object.Destroy(obj);
    }
    #endregion
}
