using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using MikePure.MikePure.Cheats.Menu;
using MikePure.MikePure.Cheats.Menu.SubMenu;
using MikePure.MikePure.Cheats.Overrides;
using MikePure.MikePure.Framework.Types.List;
using MikePure.MikePure.Framework.Util;
using SDG.Unturned;
using UnityEngine;
using Friends = MikePure.MikePure.Framework.Types.List.Friends;
using Object = UnityEngine.Object;
using Player = SDG.Unturned.Player;
#pragma warning disable 169

namespace MikePure.MikePure.Framework.Handler
{
    internal class HackDirector
    {
        #region TODO

        //TODO: Implement Hook                                                V
        //TODO: Generate AP call loop                                         V
        //TODO: Generate HD methods                                           v                            
        //TODO: Add GO Manipulation to HD                                     V
        //TODO: Implement local loading in LFH                                
        //TODO: Add methods for editing local files during runtime            
        //TODO: populate coloroption enum                                     V
        //TODO: populate nvoption enum                                        v
        //TODO: add members to friend                                         v
        //TODO: Add members to Gunasset based on tsunami                      v
        //TODO: Add members to keybind                                        v
        //TODO: Populate submenus with feature specific variables             
        //TODO: Add sub methods for start, update, etc in partial classes
        //TODO: flesh menuhandler with universal items
        //TODO: Add menucontroller to menuhandler
        //TODO: Populate logging based on tsunami                             v
        //TODO: Populate PlayerManipulation with related methods              v
        //TODO: Add SubObject to Menuhandler
        
            #region Aim
                //TODO: Flesh menu
                //TODO: Add Aimbot
                    //TODO: Add FOV Circle
                    //TODO: Add distance to player, distance to xhair, danger settings
                //TODO: Add Aimlock
                //TODO: Add Triggerbot 
            #endregion
            #region Visuals
                //TODO: Flesh Menu
                //TODO: Add 2d box
                //TODO: Add 3d Box
                //TODO: Add Skeleton
                //TODO: Add Snaplines (Tracers)
                //TODO: Add Glow (Just add this for main shit to save headache
                //TODO: Add Labels
                    //TODO: Add player Health, Name, Distance, Weapon, Etc
                    //TODO: Add zombie (ditto)
                    //TODO: Add Storages
                    //TODO: Add Vehicles
                    //TODO: Add Items (Make sure to interface correctly with itemselection
                    //TODO: Add Animals
                    //TODO: Add Admin Overhead warning
                    //TODO: Add scaling
                //TODO: Add admin chat warning
                //TODO: Add Environment
                //TODO: Add Getting high
                //TODO: Add NV
                //TODO: Add Set time
                //TODO: Add Set zoom / zoom without scope
                //TODO: Add Color Interfacing
            #endregion
            #region ItemSelection
                //TODO: Find way to get actual item id list for item selection
                //TODO: Flesh Menu
                //TODO: Interace with item menu
            #endregion
            #region Keybinds
                //TODO: Flesh Menu
                //TODO: Add Dynamic list
                //TODO: Add Changing
                //TODO: Add MenuToggle, Aimbottoggle, panic toggle, esptoggle, others
            #endregion
            #region Player
                //TODO: Flesh menu
                    //TODO: Add Friends system (This is a royal pain in the ass btw)
                //TODO: Add gun mods
                //TODO: Add Camera freeflight
                //TODO: Add Advanced Rangefinder / Player Info (Find better name for this)
                //TODO: Add Vehicle fly

            #endregion
        
        #endregion

        internal static GameObject    goMasterObj;

        public static bool            bHackEnabled;
        public static bool            bSpying;
        
        public static MenuHandler     mhHandler;
        public static KeybindHandler  khHandler;
        
        public static Friends         fFriendsList;

        public static AssetBundle     abAssets;
        public static GUISkin         sSkin;
        public static Texture         tCursor;
        
        
        public static void Start()
        {
            try {
                abAssets = AssetBundle.LoadFromFile($@"{Application.dataPath}\\resoucemanager.assetbundle", 0U);
                if(abAssets != null)
                    sSkin = abAssets.LoadAllAssets<GUISkin>().First();
            } catch(Exception e) { Log.e(e); }

            bHackEnabled = true;
            
            MethodInfo Orig_AskScreenshot = typeof(Player).GetMethod("askScreenshot", BindingFlags.Instance | BindingFlags.Public);
            MethodInfo Over_AskScreenshot = typeof(OV_Player).GetMethod("askScreenshot", BindingFlags.Instance | BindingFlags.Public);
            RedirectionHelper.RedirectCalls(Orig_AskScreenshot, Over_AskScreenshot);
            
        }    

        public static void Update()
        {
            //Add Object if its not in the game and its not disabled
            if (Provider.isConnected && goMasterObj == null && bHackEnabled)
            {
                goMasterObj = new GameObject();

                mhHandler = goMasterObj.AddComponent<MenuHandler>();
                khHandler = goMasterObj.AddComponent<KeybindHandler>();
                Object.DontDestroyOnLoad(mhHandler);
                Object.DontDestroyOnLoad(khHandler);
            }

            if (!Provider.isConnected || !bHackEnabled)
            {
                mhHandler.DestroySubMenus();
                Object.Destroy(goMasterObj);
                mhHandler = null;
            }
        }
        
    }
}