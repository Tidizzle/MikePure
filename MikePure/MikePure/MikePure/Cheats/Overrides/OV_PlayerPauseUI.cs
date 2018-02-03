using SDG.Unturned;
using UnityEngine;
using MikePure.MikePure.Framework.Handler;

namespace MikePure.MikePure.Cheats.Overrides
{
    internal class OV_PlayerPauseUI
    {

        internal static GameObject ObjRef;
        internal static bool Hooked = false;

        private static void onClickedExitButton(SleekButton button)
        {
            Provider.disconnect();
        }

        private static void onClickedDisplayButton(SleekButton button)
        {
            if (!Hooked)
            {
                ObjRef = new GameObject();
                var inst = ObjRef.AddComponent<HackDirector>();
                Object.DontDestroyOnLoad(inst);
                Hooked = true;
            }
        }

    }
}