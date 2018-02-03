using System;
using System.Linq;
using System.Reflection;
using MikePure.MikePure.Cheats.Menu;
using MikePure.MikePure.Cheats.Overrides;
using MikePure.MikePure.Framework.Util;
using SDG.Unturned;
using UnityEngine;
using Object = UnityEngine.Object;
using Player = SDG.Unturned.Player;
#pragma warning disable 169

namespace MikePure.MikePure.Framework.Handler 
{
    internal class HackDirector : MonoBehaviour
    {
        #region TODO

        //TODO: Implement local loading in LFH                                
        //TODO: Add methods for editing local files during runtime            
        
            #region Aim   
                    //TODO: Add FOV Circle                                    
                    //TODO: Add distance to player, distance to xhair, danger settings
            #endregion
            #region Visuals
                //TODO: Add 2d box                                                                  v
                //TODO: Add 3d Box                                                                  v
                //TODO: Add Skeleton                                                                v
                //TODO: Add Glow (Just add this for main shit to save headache
                //TODO: Add Labels                                                                  v
                    //TODO: Add player Health, Name, Distance, Weapon, Etc
                    //TODO: Add zombie (ditto)
                    //TODO: Add Storages
                    //TODO: Add Vehicles
                    //TODO: Add Items (Make sure to interface correctly with itemselection)
                    //TODO: Add Animals
                    //TODO: Add Admin Overhead warning
                    //TODO: Add scaling
                //TODO: Add admin chat warning                                                       
                //TODO: Add Environment                                                             v
                //TODO: Add Getting high                                                            v                       
                //TODO: Add NV                                                                      v
                //TODO: Add Set time        
                //TODO: Add Set zoom / zoom without scope
                //TODO: Add Color Interfacing                                                       v
            #endregion
            #region ItemSelection
                //TODO: Find way to get actual item id list for item selection                    
            #endregion
            #region Player
                //TODO: Flesh menu                                                                  v
                    //TODO: Add Friends system (This is a royal pain in the ass btw)                v
                //TODO: Add gun mods                                                                v
                //TODO: Add Camera freeflight                                                       v
                //TODO: Add Advanced Rangefinder / Player Info (Find better name for this)          v
                //TODO: Add Vehicle fly                                                             v

            #endregion
        
        #endregion

        internal static GameObject    goMasterObj;
        internal static bool          overridden;

        public static bool            bHackEnabled;
        public static bool            bSpying;
        
        public static MenuHandler     mhHandler;
        public static KeybindHandler  khHandler;
        
        public static AssetBundle     abAssets;
        public static AssetBundle     abSkinBundle;
        public static GUISkin         sSkin;
        public static Texture         tCursor;
        public static Texture         tWatermark;

        
        
        
        public void Start()
        {
            try {
                abAssets = AssetBundle.LoadFromFile($@"{Application.dataPath}\resourcemanager.assetbundle", 0U);
                if(abAssets != null)
                    sSkin = abAssets.LoadAllAssets<GUISkin>().First();
                    tWatermark = abAssets.LoadAsset("MikePure") as Texture;
            } catch(Exception e) { Log.e(e); }

            bHackEnabled = true;
            
            Log.log("Mikepure Loaded");
        }    

       
        
        public void Update()
        {
            //Add Object if its not in the game and its not disabled
            if (Provider.isConnected && goMasterObj == null && bHackEnabled)
            {
                goMasterObj = new GameObject();

                mhHandler = goMasterObj.AddComponent<MenuHandler>();
                khHandler = goMasterObj.AddComponent<KeybindHandler>();
                DontDestroyOnLoad(mhHandler);
                DontDestroyOnLoad(khHandler);

                if (overridden == false)
                {
                    var Orig_AskScreenshot = typeof(Player).GetMethod("askScreenshot", BindingFlags.Instance | BindingFlags.Public);
                    var Over_AskScreenshot = typeof(OV_Player).GetMethod("askScreenshot", BindingFlags.Instance | BindingFlags.Public);
                    RedirectionHelper.RedirectCalls(Orig_AskScreenshot, Over_AskScreenshot);

                    var Orig_sendRaycast = typeof(PlayerInput).GetMethod("sendRaycast", BindingFlags.Instance | BindingFlags.Public);
                    var Over_sendRaycast = typeof(OV_PlayerInput).GetMethod("sendRaycast", BindingFlags.Instance | BindingFlags.Public);
                    RedirectionHelper.RedirectCalls(Orig_sendRaycast, Over_sendRaycast);

                    var Orig_onClickExit = typeof(PlayerPauseUI).GetMethod("onClickedExitButton", BindingFlags.Static | BindingFlags.NonPublic);
                    var Over_onClickExit = typeof(OV_PlayerPauseUI).GetMethod("onClickedExitButton", BindingFlags.Static | BindingFlags.NonPublic);
                    RedirectionHelper.RedirectCalls(Orig_onClickExit, Over_onClickExit);

                    overridden = true;
                }
                    
            }

            if (!Provider.isConnected || !bHackEnabled)
            {
                if (goMasterObj != null)
                {
                    mhHandler.DestroySubMenus();
                    Destroy(goMasterObj);
                    mhHandler = null;
                }
            }

        }
        
    }
}