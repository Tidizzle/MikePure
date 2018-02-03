using Dire_Wolf.DireWolf.Manager;
using Dire_Wolf.DireWolf.Menu;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace Dire_Wolf.DireWolf.Util
{
    internal static class ToolMenu
    {
        public static float GetDistance(Vector3 point)
        {
            return Vector3.Distance(Camera.main.transform.position, point);
        }
        
        public static bool IsFriendSteam(Player player)
        {
            if (Aim.IgnoreGroup)
            {
                if (Characters.active.group != CSteamID.Nil && player.channel.owner.playerID.group == Characters.active.group)
                    return true;
            }
            return false;
        }

    }
}
