using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class test : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Main.Pool.Push(other.gameObject, true);
    }

    
}
