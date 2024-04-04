using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman_Food : MonoBehaviour
{

    public void Eated()
    {
        Main.Pool.Push(gameObject);
        Main.Spawn.InitIntantiateFood(1, Define.PrefabName.food);
        

    }
}
