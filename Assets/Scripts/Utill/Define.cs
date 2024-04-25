using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Define 
{
    public struct SceneName
    {
        public static string Title = "TitleScene";
        public static string Game = "GameScene";
        public static string Boss = "BossScene";
    }


    public struct PrefabName
    {
        public static string Floor = "Floor";
        public static string Stickman = "Stickman";
        public static string StickmanPlayer = "StickmanPlayer";
        public static string StickmanEnemy = "StickmanEnemy";
        public static string StickmanBoss = "StickmanBoss";
        public static string Joystick = "JoyStickPanel";
        //public static string Food = "Stickman_Food";
        public static string Food = "Food_Burger";
        public static string StickmanMaterial = "Skin_Color";
        public static string PlayerCamera = "PlayerCamera";
        public static string SplatEffect = "Splat_";

        public static string AudioSource_sfx = "AudioSource_sfx";
        public static string AudioSource_bgm = "AudioSource_bgm";
    }

    public struct AudioType
    {
        public const string bgm = "BGM";
        public const string sfx = "SFX";
        public const string master = "Master";
    }

    public struct Audio_BGM
    {
        public const string Title = "BGM_Title";
        public const string Game = "BGM_Game";
    }

    public struct Audio_SFX
    {
        public const string StickmanEat = "SFX_StickmanEat";
    }


    public struct TagName
    {
        public static string Player = "Player";
        public static string Head = "Head";
        public static string Enemy = "Enemy";
        public static string Boss = "Boss";

    }


    public static string FoodPrefabName()
    {
        int num = Random.Range(0, 5);

        switch (num)
        {
            case 0:
                return "Food_Tomato";
            case 1:
                return "Food_Banana";
            case 2:
                return "Food_Donut";
            case 3:
                return "Food_Fish";
            case 4:
                return "Food_Burger";
        }

        return null;
    }

    public static string RankingUnit(int rank)
    {
        switch(rank)
        {
            case 1:
                return " st";
            case 2:
                return " nd";
            case 3:
                return " rd";
            default:
                return " th";
        }
    }


    public static int StartTime = 80;
   
}
