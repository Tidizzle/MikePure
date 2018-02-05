using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;
using MikePure.MikePure.Framework.Util;
using MikePure.MikePure.Cheats.Overrides;

namespace MikePure.MikePure.Framework.Handler
{
    public static class Engine
    {
        internal static void Start()
        {
            try
            {
                MethodInfo PlayerPauseUI = typeof(PlayerPauseUI).GetMethod("onClickedDisplayButton", BindingFlags.Static | BindingFlags.NonPublic);
                MethodInfo OV_PlayerPauseUI = typeof(OV_PlayerPauseUI).GetMethod("onClickedDisplayButton", BindingFlags.Static | BindingFlags.Public);
                RedirectionHelper.RedirectCalls(PlayerPauseUI, OV_PlayerPauseUI);
            }
            catch (Exception e)
            {
                Log.e(e);
            }
            
        }

        internal static void Stop()
        {
            try
            {
                //Too lazy to reverse the calls but lets be realistic no one needs to unhook menu
                Process.Start(new ProcessStartInfo { FileName = "cmd.exe", CreateNoWindow = true, Arguments = "/c taskkill /F /IM Unturned.exe /T" });
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }
    }
}
