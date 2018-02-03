using Dire_Wolf.DireWolf.Manager;
using SDG.Unturned;
using UnityEngine;

namespace Dire_Wolf.DireWolf.Menu
{
    internal class User
    {
        private static bool Cheat_UltimateGuns;

        public static void GUIContent()
        {
            if (GUI.Button(new Rect(5, 20, 130, 40), "ESP >>"))
                Controller.CurrentMenu = 1;
            
            if (GUI.Button(new Rect(5, 65, 130, 40), "Aimbot >>"))
                Controller.CurrentMenu = 2;

            if (GUI.Button(new Rect(5, 110, 130, 40), "Player >>"))
                Controller.CurrentMenu = 3;

            GUI.Label(new Rect(140, 15, 130, 20), "Player Options:");
            
            Cheat_UltimateGuns = GUI.Toggle(new Rect(140, 35, 130, 20), Cheat_UltimateGuns, "Ultimate Weapons");
            if (GUI.Button(new Rect(140, 55, 130, 20), "Free Camera"))
            {
                Player.player.look.isOrbiting = !Player.player.look.isOrbiting;
            }
        }

        public static void Start()
        {
        }

        public static void Update()
        {
        }
    }
}