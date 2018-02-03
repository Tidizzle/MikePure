using System;
using System.Collections;
using System.Collections.Generic;
using Dire_Wolf.DireWolf.Manager;
using HighlightingSystem;
using JetBrains.Annotations;
using SDG.Unturned;
using UnityEngine;

namespace Dire_Wolf.DireWolf.Menu
{
    internal class Menu : MonoBehaviour
    {
        //Menu Options
        public bool IsWelcomeShown = true;
        public bool IsMenuShown = false;
        public bool IsEspShown = false;
        public bool IsAimbotShown = false;
        public bool IsPlayerShown = false;

        //Rects
        public static Rect MenuRect = new Rect(10, 10, 400, 190);
        public static Rect CursorRect = new Rect(10, 10, 20, 20);

        //Definations

        public void Start()
        {
            Aim.Start();
            Esp.Start();
            User.Start();
        }
        
        public void Update()
        {
            Aim.Update();
            Esp.Update();
            User.Update();
        }
        
        public void OnGUI()
        {
             if (Controller.MenuOpen)
             {
                 MenuRect = GUI.Window(0, MenuRect, MenuContent, "<b><size=14><Color=Purple>MikePure</color></size></b>");
             }
        }

        private void MenuContent(int winID)
        {
            GUI.depth = 1;

            switch (Controller.CurrentMenu)
            {
                case 1:
                    Esp.GUIContent();
                    break;
                case 2:
                    Aim.GUIContent();
                    break;
                case 3:
                    User.GUIContent();
                    break;
            }
            
            if (Controller.Cursor != null)
            {
                GUI.depth = -9999;
                GUI.color = new Color(1f, 1f, 1f, 0.8f);
                CursorRect.x = Input.mousePosition.x;
                CursorRect.y = Screen.height - Input.mousePosition.y;
                GUI.DrawTexture(CursorRect, Controller.Cursor);
            }
            GUI.DragWindow();
        }



        





    }
}
