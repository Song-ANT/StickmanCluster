using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager 
{
    public void InitInstantiatePlayer(string initObject)
    {
        var player = Main.Resource.InstantiatePrefab(initObject);
        Main.Cinemachine.SetPlayerStickmanCamera(player.transform);
    }

    public void InitInstantiatePlayer(int initCount, string initObject)
    {
        var player = Main.Resource.InstantiatePrefab(initObject);
        Main.Cinemachine.SetPlayerStickmanCamera(player.transform);

        StickmanController controller = player.GetComponent<StickmanController>();
        controller.MakeStickman(initCount - 1);
    }

    public void InitInstantiateBoss(string initObject)
    {
        var Boss = Main.Resource.InstantiatePrefab(initObject);

        Boss.transform.position = new Vector3(0, 0, 30);
        Boss.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));

        StickmanController controller = Boss.GetComponent<StickmanController>();
        controller.MakeStickman(Main.Game.BossLv - 1);
    }

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


    public void InitInstantiateFood(int initCount, string initObject)
    {
        for (int i = 0; i < initCount; i++)
        {
            float x = Random.Range(-50f, 50f);
            float y = Random.Range(-50f, 50f);

            Vector3 pos = new Vector3(x, 0, y);
            Quaternion rot = Quaternion.identity;

            GameObject food = Main.Resource.InstantiatePrefab(initObject, pos, rot, true);

            food.transform.position = pos;
            food.transform.rotation = rot;
        }
    }
}
