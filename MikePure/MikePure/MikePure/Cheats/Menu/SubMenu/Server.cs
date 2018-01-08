using System.Collections.Generic;
using MikePure.MikePure.Framework.Types;
using MikePure.MikePure.Framework.Types.List;
using SDG.SteamworksProvider.Services.Browser;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    internal class Server : MonoBehaviour
    {
        
        public ulong playerfocus;
        
        public Vector2 PlayerScroll;
        public Vector2 FriendScroll;
        
        internal List<Friend> Addlist;
        internal List<Friend> Remlist;

        internal ulong Playerfocus;
        internal ulong Friendfocus;

        public void Start()
        {
            Addlist = new List<Friend>();
            Remlist = new List<Friend>();

            PlayerScroll = new Vector2();
            FriendScroll = new Vector2();

            Playerfocus = 0;
            Friendfocus = 0;
        }

        public void Update()
        {
            if (Provider.isConnected)
            {
                if (Remlist.Count != 0)
                {
                    foreach (var rem in Remlist)
                    {
                        Friends.FriendsList.Remove(rem);
                    }

                    Remlist = new List<Friend>();
                }

                if (Addlist.Count != 0)
                {
                    foreach (var add in Addlist)
                    {
                        Friends.FriendsList.Add(add);
                    }

                    Addlist = new List<Friend>();
                }
            }
        }

        public void ContentGUI()
        {
            
            GUILayout.BeginHorizontal();
            //Player list
            GUILayout.BeginVertical();

            GUILayout.Label("<size=15>Players</size>", GUILayout.Width(100));
            
            GUILayout.BeginScrollView(PlayerScroll, false, true, GUILayout.Height(250));

            if (Provider.clients.Count == 1)
            {
                GUILayout.Button("No Players", GUILayout.Width(150));
            }
            else
            {
                foreach (var player in Provider.clients)
                {
//                    if (player.player == SDG.Unturned.Player.player) return;
//                    if (Friends.IsFriend(player.playerID.steamID.m_SteamID)) return;

                    if (GUILayout.Button($"<size=13>{player.playerID.nickName}</size>", GUILayout.Width(150)))
                    {
                        Addlist.Add(new Friend(player.playerID.nickName, player.playerID.steamID.m_SteamID));
                    }
                 
                }
            }
            
            GUILayout.EndScrollView();
            
            
            GUILayout.EndVertical();
            
            
            
//            Friends list
//            GUILayout.BeginVertical();
//
//            GUILayout.Label("<size=15>Friends</size>", GUILayout.Width(100));
//            
//            GUILayout.BeginScrollView(FriendScroll, false, true);
//
//            
//            GUILayout.EndScrollView();
//                       
//            
//            GUILayout.EndVertical();
//            
            GUILayout.EndHorizontal();
        }
        
        
    }
}