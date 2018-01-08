using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MikePure.MikePure.Cheats.Menu.SubMenu;
using MikePure.MikePure.Framework.Handler;
using MikePure.MikePure.Framework.Types;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu
{
    internal class KeybindHandler : MonoBehaviour
    {
        public KeyCode WindowKey;
        public KeyCode AimbotToggle;
        public KeyCode InstaDisconnect;
        public KeyCode EspToggle;
        
        
        public bool Changing;
        public int ChangeFocus;
        
        public void Start()
        {
            //Temporary while we set up changing
            WindowKey = KeyCode.F1;
            AimbotToggle = KeyCode.LeftControl;
            InstaDisconnect = KeyCode.Pause;
            EspToggle = KeyCode.Delete;

        }

        public void Update()
        {
            if (Event.current.type == EventType.KeyDown)
            {
                if (Changing)
                {
                    var key = Event.current.keyCode;

                    if (key == WindowKey || key == AimbotToggle || key == InstaDisconnect || key == EspToggle) return;

                    switch (ChangeFocus)
                    {
                        case 1:
                            WindowKey = key;
                            break;
                        case 2:
                            AimbotToggle = key;
                            break;
                        case 3:
                            EspToggle = key;
                            break;
                        case 4:
                            InstaDisconnect = key;
                            break;
                    }

                    Changing = false;
                }
                else
                {
                    var pressed = Event.current.keyCode;

                    if (pressed == WindowKey)
                    {
                        HackDirector.mhHandler.MenuVis = !HackDirector.mhHandler.MenuVis;

                        if (HackDirector.mhHandler.MenuVis)
                        {
                            PlayerPauseUI.active = true;
                            PlayerUI.window.showCursor = true;
                        }
                        else
                        {
                            PlayerPauseUI.active = false;
                            PlayerUI.window.showCursor = false;
                        }
                    }
                    else if (pressed == AimbotToggle)
                        Aim.EnableAimbot = !Aim.EnableAimbot;
                    else if (pressed == InstaDisconnect)
                    {
                        var psi = new ProcessStartInfo();
                        psi.FileName = "cmd.exe";
                        psi.CreateNoWindow = true;
                        psi.Arguments = "/c taskkill /F /IM Unturned.exe /T";
                        Process.Start(psi);
                    }
                    else if (pressed == EspToggle)
                        Visuals.EnableVisuals = !Visuals.EnableVisuals;
                    else if (pressed == KeyCode.Escape && HackDirector.mhHandler.MenuVis)
                    {
                        HackDirector.mhHandler.MenuVis = false;

                        PlayerPauseUI.active = false;
                        PlayerUI.window.showCursor = false;
                    }
                        
                    
                }
            }

        }
        
        
    }
}