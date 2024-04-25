using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager 
{
    public int BossLv = 200;
    private int _clearGold = 0;

    public int ClearGold => _clearGold;

    public void BossClear()
    {
        BossLv *= 2;
    }

    public void SetClearGold(int clearGold)
    {
        _clearGold = clearGold;
        Main.Player.GoldPlus(clearGold);
    }
}
