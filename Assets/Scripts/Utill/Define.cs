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
    }

    public struct TagName
    {
        public static string Player = "Player";
        public static string Head = "Head";
        public static string Enemy = "Enemy";
        public static string Boss = "Boss";

    }

    
    public static int StartTime = 15;
   
}
