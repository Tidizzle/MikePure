using System.Collections.Generic;
using MikePure.MikePure.Cheats.Menu.SubMenu;
using MikePure.MikePure.Framework.Handler;
using MikePure.MikePure.Framework.Util;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu
{
    internal class MenuHandler : MonoBehaviour
    {
        public Aim                 mAim;
        internal ItemSelection     mItems;
        internal Keybinds          mKeybinds;
        internal Player            mPlayer;
        internal Visuals           mVisuals;
        internal Server            mServer;

        public int ContentId;
        public bool MenuVis;

        public Rect MenuRect;
        public int width = 650;
        public int height = 364;
        public Rect CursorRect = new Rect(0, 0, 20, 20);

        public static Rect RadarRect = new Rect(Screen.width - 400, 150, 240, 250);


        public void Start()
        {
            AddSubMenus();
            MenuRect = new Rect(Screen.width / 2 - width / 2, Screen.height / 2 - height / 2, width, height);
            ContentId = 1;
        }

        public void Update()
        {
            if (HackDirector.bSpying) return;
            
        }

        public void OnGUI()
        {
            if (HackDirector.bSpying) return;

            ShowWaterMark();
            
            if (HackDirector.tCursor == null && MenuVis)
                HackDirector.tCursor = Resources.Load("UI/Cursor") as Texture;

            GUI.skin = HackDirector.sSkin;

            mVisuals.DerivedOnGUI();
            
            if (MenuVis)
            {
                MenuRect = GUILayout.Window(0, MenuRect, MenuFunct, "<size=15><b><color=#009E06>MIKE</color></b><i><color=#8F23C6>PURE</color></i></size>");
                
                if (HackDirector.tCursor != null)
                {
                    GUI.depth = 0;
                    GUI.color = new Color(1f, 1f, 1f, 0.8f);
                    CursorRect.x = Input.mousePosition.x;
                    CursorRect.y = Input.mousePosition.y;
                    CursorRect.y = Screen.height - CursorRect.y;
                    GUI.DrawTexture(CursorRect, HackDirector.tCursor);

                }
            }
            
//            RadarRect = GUI.Window(1, RadarRect, RadarFunct, "Radar");


        }

        public void ShowWaterMark()
        {
            GUI.depth = 0;
            var loctex = HackDirector.tWatermark;
            var posrect = new Rect(Screen.width - 290, -15, 285, 100);
            
            GUI.DrawTexture(posrect, loctex);
        }
        
        public void MenuFunct(int id)
        {
            
            GUILayout.BeginHorizontal();
            
            
            #region menu bar
            //Menu Bar vertical section
            GUILayout.BeginVertical();

            if (GUILayout.Button("<size=20>Player</size>" ,GUILayout.Width(200),  GUILayout.Height(40)))
                ContentId = 3;
            
            GUILayout.Space(7f);
            
            if (GUILayout.Button("<size=20>Aim</size>" ,GUILayout.Width(200),  GUILayout.Height(40)))
                ContentId = 1;
            
            GUILayout.Space(7f);
            
            if (GUILayout.Button("<size=20>Visuals</size>" ,GUILayout.Width(200),  GUILayout.Height(40)))
                ContentId = 2;
            
            GUILayout.Space(7f);
            
            if (GUILayout.Button("<size=20>Server</size>" ,GUILayout.Width(200),  GUILayout.Height(40)))
                ContentId = 4;
            
            GUILayout.Space(7f);
                        
            if (GUILayout.Button("<size=20>Item Filter</size>" ,GUILayout.Width(200),  GUILayout.Height(40)))
                ContentId = 5;
            
            GUILayout.Space(7f);
            
            if (GUILayout.Button("<size=20>Keybinds</size>" ,GUILayout.Width(200),  GUILayout.Height(40)))
                ContentId = 6;
            
            GUILayout.EndVertical();
            
            GUILayout.Space(10f);

            #endregion



            GUI.depth = 1; //Cursor Fix

            //Menu Content section
            GUILayout.BeginVertical();
            switch (ContentId)
            {
                    case 1:
                        mAim.ContentGUI();
                        break;
                    case 2:
                        mVisuals.ContentGUI();
                        break;
                    case 3:
                        mPlayer.ContentGUI();
                        break;
                    case 5:
                        mItems.ContentGUI();
                        break;
                    case 6:
                        mKeybinds.ContentGUI();
                        break;
                    case 4:
                        mServer.ContentGUI();
                        break;
            }
            GUILayout.EndVertical();

           


            GUILayout.EndHorizontal();
            
        }
        
        public void DestroySubMenus()
        {
            Destroy(mAim);
            Destroy(mItems);
            Destroy(mKeybinds);
            Destroy(mPlayer);
            Destroy(mVisuals);
            Destroy(mServer);
        }

        public void AddSubMenus()
        {
            mAim = HackDirector.goMasterObj.AddComponent<Aim>();
            mItems = HackDirector.goMasterObj.AddComponent<ItemSelection>();
            mKeybinds = HackDirector.goMasterObj.AddComponent<Keybinds>();
            mPlayer = HackDirector.goMasterObj.AddComponent<Player>();
            mVisuals = HackDirector.goMasterObj.AddComponent<Visuals>();
            mServer = HackDirector.goMasterObj.AddComponent<Server>();
        }
        
        public static void RadarFunct(int id)
        {
            GUI.DragWindow();


        }
    }
}