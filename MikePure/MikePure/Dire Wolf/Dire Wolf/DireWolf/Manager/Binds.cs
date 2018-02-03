using SDG.Unturned;
using UnityEngine;

namespace Dire_Wolf.DireWolf.Manager
{
    internal class Binds : MonoBehaviour
    {
        public KeyCode MenuKey;

        public void Start()
        {
            MenuKey = KeyCode.F1;
        }

        public void Update()
        {
            if (Event.current.type == EventType.KeyDown)
            {
                var pressed = Event.current.keyCode;

                if (pressed == MenuKey)
                {
                    UseMenu();
                }
            }
        }

        public void UseMenu()
        {
            if (Controller.MenuOpen)
            {
                Controller.MenuOpen = false;
                PlayerPauseUI.active = false;
                PlayerUI.window.showCursor = false;
            }
            else
            {
                Controller.MenuOpen = true;
                PlayerPauseUI.active = true;
                PlayerUI.window.showCursor = true;
            }
            
        }
    }



        
      
}