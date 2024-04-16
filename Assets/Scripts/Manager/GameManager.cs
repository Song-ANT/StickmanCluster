using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
    public int BossLv = 50;

    public void BossClear()
    {
        BossLv += 20;
    }
}
