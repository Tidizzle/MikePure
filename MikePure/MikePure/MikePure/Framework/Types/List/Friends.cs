using System.Collections.Generic;

namespace MikePure.MikePure.Framework.Types.List
{
    internal class Friends
    {
        public static List<Friend> FriendsList;
        
        public static bool IsFriend(ulong steamid)
        {
            if (FriendsList == null)
            {
                FriendsList = new List<Friend>();
                return false;
            }
                
            foreach (var user in FriendsList)
            {
                if (user.ulSteamId == steamid)
                    return true;
            }

            return false;
        }
        
        

    }
}