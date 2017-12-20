using System.Collections.Generic;
using MikePure.MikePure.Cheats.Menu.SubMenu;
using MikePure.MikePure.Framework.Handler;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu
{
    internal class MenuHandler : MonoBehaviour
    {
        private Aim               _mAim;
        private ItemSelection     mItems;
        private Keybinds          mKeybinds;
        private Player            mPlayer;
        private Visuals           mVisuals;

        public int ContentId;
        public bool MenuVis;

        public Rect MenuRect;
        public int width = 740;
        public int height = 404;
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
            
            //Menu Bar vertical section
            GUILayout.BeginVertical(GUILayout.Width(240));

            if (GUILayout.Button("Aim"))
            {
                
            }
            
            GUILayout.EndVertical();
            
            //Menu Content section
            GUILayout.BeginVertical();
            
            GUILayout.EndVertical();
            
           GUILayout.EndHorizontal();
        }
        
        public void DestroySubMenus()
        {
            Destroy(_mAim);
            Destroy(mItems);
            Destroy(mKeybinds);
            Destroy(mPlayer);
            Destroy(mVisuals);
        }

        public void AddSubMenus()
        {
            _mAim = HackDirector.goMasterObj.AddComponent<Aim>();
            mItems = HackDirector.goMasterObj.AddComponent<ItemSelection>();
            mKeybinds = HackDirector.goMasterObj.AddComponent<Keybinds>();
            mPlayer = HackDirector.goMasterObj.AddComponent<Player>();
            mVisuals = HackDirector.goMasterObj.AddComponent<Visuals>();
        }
        
    }
}