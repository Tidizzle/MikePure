using System.Collections.Generic;
using MikePure.MikePure.Cheats.Menu.SubMenu;
using MikePure.MikePure.Framework.Handler;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu
{
    internal class MenuHandler : MonoBehaviour
    {
        private Aim               mAim;
        private ItemSelection     mItems;
        private Keybinds          mKeybinds;
        private Player            mPlayer;
        private Visuals           mVisuals;

        public int ContentId;
        public bool MenuVis;

        public Rect MenuRect;
        public int width = 840;
        public int height = 504;
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
                MenuRect = GUI.Window(0, MenuRect, MenuFunct, "MikePure");

        }

        public void MenuFunct(int id)
        {
            if (GUI.Button(new Rect(5, 5, 150, 35), "Player"))
                ContentId = 1;
            if (GUI.Button(new Rect(5, 45, 150, 35), "Aim"))
                ContentId = 2;
            if (GUI.Button(new Rect(5, 85, 150, 35), "Visuals"))
                ContentId = 3;
            if (GUI.Button(new Rect(5, 125, 150, 35), "Item Filter"))
                ContentId = 4;
            if (GUI.Button(new Rect(5, 165, 150, 35), "Keybinds"))
                ContentId = 5;

            switch (ContentId)
            {
                    case 1:
                        mPlayer.GUI();
                        break;
                    case 2:
                        mAim.GUI();
                        break;
                    case 3:
                        mVisuals.GUI();
                        break;
                    case 4:
                        mItems.GUI();
                        break;
                    case 5:
                        mKeybinds.GUI();
                        break;
            }
        }
        
        public void DestroySubMenus()
        {
            Destroy(mAim);
            Destroy(mItems);
            Destroy(mKeybinds);
            Destroy(mPlayer);
            Destroy(mVisuals);
        }

        public void AddSubMenus()
        {
            mAim = HackDirector.goMasterObj.AddComponent<Aim>();
            mItems = HackDirector.goMasterObj.AddComponent<ItemSelection>();
            mKeybinds = HackDirector.goMasterObj.AddComponent<Keybinds>();
            mPlayer = HackDirector.goMasterObj.AddComponent<Player>();
            mVisuals = HackDirector.goMasterObj.AddComponent<Visuals>();
        }
        
    }
}