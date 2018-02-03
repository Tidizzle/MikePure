using Dire_Wolf.DireWolf.Manager;
using UnityEngine;

namespace Dire_Wolf.DireWolf.Menu
{
     
    internal partial class Esp
    {
        public static int EspDistance = 300;
        public static bool IsEspEnabled = false;
        public static bool EspGlow = false;
        public static bool EspBoxName = false;
        public static Color EspColor = new Color(0.28f, 0.8f, 1f, 1f);

        public static void GUIContent()
        {
            if (GUI.Button(new Rect(5, 20, 130, 40), "ESP >>"))
                Controller.CurrentMenu = 1;
            
            if (GUI.Button(new Rect(5, 65, 130, 40), "Aimbot >>"))
                Controller.CurrentMenu = 2;

            if (GUI.Button(new Rect(5, 110, 130, 40), "Player >>"))
                Controller.CurrentMenu = 3;


            GUI.Label(new Rect(140, 15, 130, 20), "Player ESP:");
            
            IsEspEnabled = GUI.Toggle(new Rect(140, 35, 130, 20), IsEspEnabled, "Enable ESP");
            EspBoxName = GUI.Toggle(new Rect(140, 55, 130, 20), EspBoxName, "Box and Name");
            GUI.Label(new Rect(140, 75, 130, 20), $"Distance: [{EspDistance}]");
            EspDistance = (int)GUI.HorizontalSlider(new Rect(140f, 95, 130, 20), EspDistance, 0, 5000);
            EspGlow = GUI.Toggle(new Rect(140, 115, 130, 20), EspGlow, "Glow ESP");

        }

        public static void Start()
        {
        }

        public static void Update()
        {
        }
    }
}