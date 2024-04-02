using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickmanController : MonoBehaviour
{

    private float _distance = 1f;
    private float _radius = 1f;



    #region Init
    private void Awake()
    {
        MakeStickman(1);
    }

    private void Update()
    {
        if(transform.root.name == "StickmanPlayer" && Input.GetKeyDown(KeyCode.I)) 
        {
            MakeStickman(1); 
        }

        if(transform.root.name != "StickmanPlayer" && Input.GetKeyDown(KeyCode.O))
        {
            MakeStickman(1);
        }

    }
    #endregion




    public void MakeStickman(int num)
    {
        for (int i = 0; i < num; i++)
        {
            var temp = Main.Resource.InstantiatePrefab(Define.PrefabName.stickman, transform, true);
        }

        FormatStickman();
    }

    public void FormatStickman()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var x = _distance * Mathf.Sqrt(i) * Mathf.Cos(i * _radius);
            var y = _distance * Mathf.Sqrt(i) * Mathf.Sin(i * _radius);

            var newPos = new Vector3(x, 0, y);

            var child = transform.GetChild(i);

            if (Vector3.Distance(child.localPosition, newPos) > _distance)
            {
                child.position = transform.position;
            }

            child.DOLocalMove(newPos, 1f).SetEase(Ease.OutBack);
        }
    }
}
