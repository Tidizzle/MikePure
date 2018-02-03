using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;
using SDG.Unturned;
using System.Reflection;
using Steamworks;
using System.Diagnostics;
using System.IO;
using Dire_Wolf.DireWolf.Manager;
using Dire_Wolf.DireWolf.Util;

namespace Dire_Wolf
{
    internal class Hook : MonoBehaviour
    {
        public static GameObject HookingObject = null;
        private static Controller Ctrl = null;

        public static void HookMenu()
        {
            try
            {
                Logging.Log("Started Hooking");
                HookingObject = new GameObject();
                Ctrl = HookingObject.AddComponent<Controller>();
                DontDestroyOnLoad(Ctrl);
                Logging.Log("Finished Hooking");
            }
            catch (Exception)
            {
                Logging.Log("Failed to hook");
            }
        }

        public static void UnHookMenu()
        {
            Destroy(HookingObject);
            Logging.Log("Destroyed");
        }
    }
}