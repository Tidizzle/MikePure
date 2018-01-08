using MikePure.MikePure.Framework.Handler;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    public class Keybinds : MonoBehaviour
    {

        public void Start()
        {
    
        }
    
        public void Update()
        {
            if (HackDirector.bSpying) return;
        }
    
        public void ContentGUI()
        {
            if (HackDirector.bSpying) return;

            if (GUI.Button(new Rect(300, 20, 260, 40), $"<size=15>Menu Toggle: {HackDirector.khHandler.WindowKey}</size>"))
            {
                HackDirector.khHandler.Changing = true;
                HackDirector.khHandler.ChangeFocus = 1;
            }
            if (GUI.Button(new Rect(300, 66, 260, 40), $"<size=15>Aimbot Toggle: {HackDirector.khHandler.AimbotToggle}</size>"))
            {
                HackDirector.khHandler.Changing = true;
                HackDirector.khHandler.ChangeFocus = 2;
            }
            if (GUI.Button(new Rect(300, 112, 260, 40), $"<size=15>Visuals Toggle: {HackDirector.khHandler.EspToggle}</size>"))
            {
                HackDirector.khHandler.Changing = true;
                HackDirector.khHandler.ChangeFocus = 3;
            }
            if (GUI.Button(new Rect(300, 158, 260, 40), $"<size=15>Insta Disconnect: {HackDirector.khHandler.InstaDisconnect}</size>"))
            {
                HackDirector.khHandler.Changing = true;
                HackDirector.khHandler.ChangeFocus = 4;
            }

        }
    
    }
}