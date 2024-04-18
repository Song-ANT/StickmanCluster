using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman_Food : MonoBehaviour
{

    public void Eated()
    {
        Main.Pool.Push(gameObject, true);
        Main.Spawn.InitInstantiateFood(1, Define.PrefabName.Food);
        

    }
}
