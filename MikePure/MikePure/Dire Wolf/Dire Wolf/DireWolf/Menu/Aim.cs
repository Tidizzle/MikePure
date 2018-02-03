using Dire_Wolf.DireWolf.Manager;
using UnityEngine;

namespace Dire_Wolf.DireWolf.Menu
{
    internal class Aim
    {
        private static bool AimbotEnabled = false;

        public static int AimFov = 30;
        public static int AimDistance = 300;
        public static bool IgnoreGroup;
        public static bool IgnoreDistance;
        
        public static void GUIContent()
        {
            if (GUI.Button(new Rect(5, 20, 130, 40), "ESP >>"))
                Controller.CurrentMenu = 1;
            
            if (GUI.Button(new Rect(5, 65, 130, 40), "Aimbot >>"))
                Controller.CurrentMenu = 2;

            if (GUI.Button(new Rect(5, 110, 130, 40), "Player >>"))
                Controller.CurrentMenu = 3;
            
            GUI.Label(new Rect(140, 15, 130, 20), "Aimbot options:");
            
            AimbotEnabled = GUI.Toggle(new Rect(140, 35, 130, 20), AimbotEnabled, "Enable aimbot");
            IgnoreGroup = GUI.Toggle(new Rect(140, 55, 130, 20), IgnoreGroup, "Ignore Group");
            IgnoreDistance = GUI.Toggle(new Rect(140, 75, 130, 20), IgnoreDistance, "Ignore Distance");
            
            GUI.Label(new Rect(140, 95, 130, 20), $"Aimbot FOV: {AimFov}");
            AimFov = (int) GUI.HorizontalSlider(new Rect(140, 115, 130, 20), AimFov, 1, 360);
            
            GUI.Label(new Rect(140, 125, 130, 20), $"Aim Distance: {AimDistance}");
            AimDistance = (int) GUI.HorizontalSlider(new Rect(140, 145, 130, 20), AimDistance, 10, 1000);

        }

        public static void Start()
        {
        }

        public static void Update()
        {
        }
    }
}