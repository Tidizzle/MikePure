using SDG.Unturned;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Overrides
{
    public class OV_PlayerPauseUI
    {
        private static void onClickedExitButton(SleekButton button)
        {
            Provider.disconnect();
        }
    }
}