using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MikePure.MikePure.Framework.Util;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MikePure.MikePure.Framework.Handler
{
    public static class Hook
    {
        internal static GameObject ObjRef;
        
        public static void TryHook()
        {
            //this is basic shit
            try
            {
                ObjRef = new GameObject();
                var inst = ObjRef.AddComponent<HackDirector>();
                Object.DontDestroyOnLoad(inst);
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }

        internal static void TryUnhook()
        {
            try
            {
                Object.DestroyImmediate(ObjRef);
                ObjRef = null;
            }
            catch (Exception e)
            {
                Log.e(e);
            }
        }
        
    }
}