using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stickman_Food : MonoBehaviour
{

    public void Eated()
    {
        Main.Pool.Push(gameObject, true);
        GameObject foodParent = GameObject.FindWithTag("FoodParent");
        Main.Spawn.InitInstantiateFood(1, null, foodParent.transform);
        

    }
}
