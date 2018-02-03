using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using MikePure.MikePure.Framework.Util;
using UnityEngine;
using Object = UnityEngine.Object;
using System.Reflection;
using SDG.Unturned;
using MikePure.MikePure.Cheats.Overrides;

namespace MikePure.MikePure.Framework.Handler
{
    public static class Hook
    {
        
        public static void TryHook()
        {
            Engine.Start();
        }

        internal static void TryUnhook()
        {
            Engine.Stop();
        }
        
    }
}