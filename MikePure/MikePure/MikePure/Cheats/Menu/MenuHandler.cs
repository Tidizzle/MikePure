using System.Collections.Generic;
using MikePure.MikePure.Cheats.Menu.SubMenu;
using MikePure.MikePure.Framework.Handler;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu
{
    internal class MenuHandler : MonoBehaviour
    {
        public Aim               mAim;
        internal ItemSelection     mItems;
        internal Keybinds          mKeybinds;
        internal Player            mPlayer;
        internal Server            mServer;
        internal Visuals           mVisuals;

        public int ContentId;
        public bool MenuVis;

        public Rect MenuRect;
        public int width = 650;
        public int height = 364;
        public Rect CursorRect = new Rect(10, 10, 20, 20);
        
        
        public void Start()
        {
            AddSubMenus();
            MenuRect = new Rect(Screen.width / 2 - width / 2, Screen.height / 2 - height / 2, width, height);
        }

        public void Update()
        {
            if (HackDirector.bSpying) return;
        }

        public void OnGUI()
        {
            if (HackDirector.bSpying) return;
            
            if (HackDirector.tCursor == null && MenuVis)
                HackDirector.tCursor = Resources.Load("UI/Cursor") as Texture;

            GUI.skin = HackDirector.sSkin;

            if (MenuVis)
                MenuRect = GUILayout.Window(0, MenuRect, MenuFunct, "MikePure");

        }

        public void MenuFunct(int id)
        {
            GUILayout.BeginHorizontal();
            
            
            #region menu bar
            //Menu Bar vertical section
            GUILayout.BeginVertical();

            if (GUILayout.Button("Aim" ,GUILayout.Width(220),  GUILayout.Height(40)))
                ContentId = 1;
            
            GUILayout.Space(7f);
            
            if (GUILayout.Button("Visuals" ,GUILayout.Width(220),  GUILayout.Height(40)))
                ContentId = 2;
            
            GUILayout.Space(7f);
            
            if (GUILayout.Button("Player" ,GUILayout.Width(220),  GUILayout.Height(40)))
                ContentId = 3;
            
            GUILayout.Space(7f);
            
            if (GUILayout.Button("Server" ,GUILayout.Width(220),  GUILayout.Height(40)))
                ContentId = 4;
            
            GUILayout.Space(7f);
            
            if (GUILayout.Button("Item Filter" ,GUILayout.Width(220),  GUILayout.Height(40)))
                ContentId = 5;
            
            GUILayout.Space(7f);
            
            if (GUILayout.Button("Keybinds" ,GUILayout.Width(220),  GUILayout.Height(40)))
                ContentId = 6;
            
            GUILayout.EndVertical();
            
            GUILayout.Space(10f);
            
            #endregion
            
            
            
            
            //Menu Content section
            GUILayout.BeginVertical();
            switch (ContentId)
            {
                    case 1:
                        mAim.ContentGUI();
                        break;
                    case 2:
                        mVisuals.GUI();
                        break;
                    case 3:
                        mPlayer.GUI();
                        break;
                    case 4:
                        mServer.GUI();
                        break;
                    case 5:
                        mItems.GUI();
                        break;
                    case 6:
                        mKeybinds.GUI();
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
        
    }
}