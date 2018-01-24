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
            
            GUILayout.BeginVertical();
            
            GUILayout.Label("<size=15>Players:</size>", GUILayout.Width(150));
            
            PlayerScroll = GUILayout.BeginScrollView(PlayerScroll, false, true, GUILayout.Width(150), GUILayout.Height(290));

            foreach (var client in Provider.clients)
            {
                if (!Friends.IsFriend(client.playerID.steamID.m_SteamID) && client.player != SDG.Unturned.Player.player)
                {
                    if (GUILayout.Button($"<size=13>{client.playerID.nickName}</size>", GUILayout.Width(125)))
                    {
                        Addlist.Add(new Friend(client.playerID.nickName, client.playerID.steamID.m_SteamID));
                    } 
                }
            }
            
            GUILayout.EndScrollView();
            GUILayout.EndVertical();

            GUILayout.BeginVertical();
            
            GUILayout.Label("<size=15>Friends:</size>");
            
            FriendScroll = GUILayout.BeginScrollView(FriendScroll, false, true, GUILayout.Width(150), GUILayout.Height(290));
            
            foreach (var client in Friends.FriendsList)
            {
                if (GUILayout.Button($"<size=13>{client.sName}</size>", GUILayout.Width(130)))
                {
                    Remlist.Add(client);
                } 
            }
            
            GUILayout.EndScrollView();
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
        }
        
        
    }
}