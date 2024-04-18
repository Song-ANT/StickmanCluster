using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using Color = UnityEngine.Color;

public class test : MonoBehaviour
{

    private void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().material.color = Color.white;
    }


}
