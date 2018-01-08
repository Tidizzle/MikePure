using System.Collections.Generic;
using MikePure.MikePure.Framework.Types;
using MikePure.MikePure.Framework.Types.List;
using SDG.Unturned;
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
            PlayerScroll.y = 1f;

            FriendScroll = new Vector2();
            FriendScroll.y = 1f;

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
            
            GUILayout.BeginScrollView(PlayerScroll);

            if (Provider.clients.Count == 0)
            {
                GUILayout.Button("<size=15>No Players On Server</size>", GUILayout.Width(100));
            }
            else
            {
                foreach (var player in Provider.clients)
                {
                    if (!Friends.IsFriend(player.playerID.steamID.m_SteamID) && player.player != SDG.Unturned.Player.player)
                    {
                        if(GUILayout.Button($"<size=15>{player.playerID.nickName}</size>", GUILayout.Width(100)))
                        {
                            playerfocus = player.playerID.steamID.m_SteamID;
                        }

                        if (playerfocus == player.playerID.steamID.m_SteamID)
                        {
                            GUILayout.BeginHorizontal();
                        
                            GUILayout.Space(5f);
                        
                            GUILayout.BeginVertical();
                            GUILayout.Label($"<size=12>Steam Name: {player.playerID.playerName}</size>", GUILayout.Width(80));
                            if (GUILayout.Button("<size=12>Add as Friend</size>", GUILayout.Width(80)))
                            {
                                playerfocus = 0;
                                Addlist.Add(new Friend(player.playerID.nickName, player.playerID.steamID.m_SteamID));
                            }
                            GUILayout.EndVertical();
                        
                            GUILayout.EndHorizontal();
                        
                        
                        }
                    }
                }
            }
            
            GUILayout.EndScrollView();
            
            
            GUILayout.EndVertical();
            
            
            //Friends list
            GUILayout.BeginVertical();

            GUILayout.Label("<size=15>Friends</size>", GUILayout.Width(100));
            
            GUILayout.BeginScrollView(FriendScroll);

            if (Friends.FriendsList.Count == 0)
            {
                GUILayout.Button($"<size=15>No Friends Added</size>", GUILayout.Width(100));
            }
            else
            {
                foreach (var ply in Friends.FriendsList)
                {
                    if(GUILayout.Button($"<size=15>{ply.sName}</size>", GUILayout.Width(100)))
                    {
                        Friendfocus = ply.ulSteamId;
                    }

                    if (Friendfocus == ply.ulSteamId)
                    {
                        GUILayout.BeginHorizontal();
                        
                        GUILayout.Space(5f);
                        
                        GUILayout.BeginVertical();
                        GUILayout.Label($"<size=12>Steam Name: {ply.sName}</size>", GUILayout.Width(80));
                        if (GUILayout.Button("<size=12>Remove Friend</size>", GUILayout.Width(80)))
                        {
                            Friendfocus = 0;
                            Remlist.Add(new Friend(ply.sName, ply.ulSteamId));
                        }
                        GUILayout.EndVertical();
                        
                        GUILayout.EndHorizontal();
                        
                        
                    }
                }
            }
            
            foreach (var player in Friends.FriendsList)
            {
                
            }
            GUILayout.EndScrollView();
                       
            
            GUILayout.EndVertical();
            
            GUILayout.EndHorizontal();
        }
        
        
    }
}