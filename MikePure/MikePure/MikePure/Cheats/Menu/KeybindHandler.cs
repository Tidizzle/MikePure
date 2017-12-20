using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MikePure.MikePure.Framework.Handler;
using MikePure.MikePure.Framework.Types;
using SDG.Unturned;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu
{
    internal class KeybindHandler : MonoBehaviour
    {
        public KeyCode WindowKey;
        public KeyCode AimbotToggle;
        public KeyCode InstaDisconnect;
        public KeyCode EspToggle;
        
        
        public bool bChanging;
        
        public void Start()
        {
            //Temporary while we set up changing
            WindowKey = KeyCode.F1;
            AimbotToggle = KeyCode.RightControl;
            InstaDisconnect = KeyCode.Pause;
            EspToggle = KeyCode.LeftAlt;

        }

        public void Update()
        {
            if (Event.current.type == EventType.KeyDown)
            {
                if (bChanging)
                {
                    //Implement when changing keys is enabled
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
                    {
                        
                    }
                    else if (pressed == InstaDisconnect)
                    {
                        ProcessStartInfo rq = new System.Diagnostics.ProcessStartInfo();
                        rq.FileName = "cmd.exe";
                        rq.Arguments = "/c Taskkill /im Unturned.exe /r";
                        Process.Start(rq);
                    }
                    else if (pressed == EspToggle)
                    {
                        
                    }
                    else if (pressed == KeyCode.Escape)
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