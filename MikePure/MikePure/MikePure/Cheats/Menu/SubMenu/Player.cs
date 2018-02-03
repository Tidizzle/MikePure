using System;
using System.Collections.Generic;
using System.Reflection;
using MikePure.MikePure.Framework.Handler;
using MikePure.MikePure.Framework.Types;
using MikePure.MikePure.Framework.Types.List;
using SDG.Unturned;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    internal class Player : MonoBehaviour
    {
        
        internal bool NoRecoil;
        internal bool NoShake;
        internal bool NoSpread;
        internal bool NoDrop;
        internal bool ChangeFov;
        internal float Fov;
        internal bool AdvRangeFinder; 
        internal bool CameraFreeFlight = false;

       
        internal static Dictionary<Guid, GunAsset> backupsrecoil = new Dictionary<Guid, GunAsset>();
        internal static Dictionary<Guid, GunAsset> backupsspread = new Dictionary<Guid, GunAsset>();
        internal static Dictionary<Guid, GunAsset> backupsshake = new Dictionary<Guid, GunAsset>();

        private FieldInfo FOV;
        
        public void Start()
        {
            Fov = 120;
            FOV = typeof(PlayerLook).GetField("fov", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public void checkWepHacks()
        {
            if (NoRecoil && SDG.Unturned.Player.player.equipment.asset is ItemGunAsset)
            {
                var asset = (ItemGunAsset) SDG.Unturned.Player.player.equipment.asset;
                var guid = asset.GUID;

                if (backupsrecoil.ContainsKey(guid) == false)
                    backupsrecoil.Add(guid, new GunAsset(asset));
                
                asset.recoilMax_x = 0f;
                asset.recoilMax_y = 0f;
                asset.recoilMin_x = 0f;
                asset.recoilMin_y = 0f;
            }
            else if (!NoRecoil && SDG.Unturned.Player.player.equipment.asset is ItemGunAsset)
            {
                var asset = SDG.Unturned.Player.player.equipment.asset as ItemGunAsset;
                var guid = asset.GUID;

                if (backupsrecoil.ContainsKey(guid))
                {
                    var backup = backupsrecoil[guid];
                    
                    asset.recoilMax_x = backup.recoilmaxx;
                    asset.recoilMax_y = backup.recoilmaxy;
                    asset.recoilMin_x = backup.recoilminx;
                    asset.recoilMin_y = backup.recoilminy;

                    backupsrecoil.Remove(guid);
                }
            }
            
            if (NoSpread && SDG.Unturned.Player.player.equipment.asset is ItemGunAsset)
            {
                var asset = (ItemGunAsset) SDG.Unturned.Player.player.equipment.asset;
                var guid = asset.GUID;
                
                if(backupsspread.ContainsKey(guid) == false)
                    backupsspread.Add(guid, new GunAsset(asset));

                asset.spreadAim = 0f;
                asset.spreadHip = 0f;
            }
            else if (!NoSpread && SDG.Unturned.Player.player.equipment.asset is ItemGunAsset)
            {
                var asset = SDG.Unturned.Player.player.equipment.asset as ItemGunAsset;
                var assetguid = asset.GUID;

                if (backupsspread.ContainsKey(assetguid))
                {
                    var backup = backupsspread[assetguid];
                    
                    asset.spreadAim = backup.spreadaim;
                    asset.spreadHip = backup.spreadhip;
                    
                    
                    backupsspread.Remove(assetguid);
                }
            }
            
            if (NoShake && SDG.Unturned.Player.player.equipment.asset is ItemGunAsset)
            {
                var asset = (ItemGunAsset) SDG.Unturned.Player.player.equipment.asset;
                var guid = asset.GUID;
                
                if(backupsshake.ContainsKey(guid) == false)
                    backupsshake.Add(guid, new GunAsset(asset));

                asset.shakeMax_x = 0f;
                asset.shakeMax_y = 0f;
                asset.shakeMax_z = 0f;
                asset.shakeMin_x = 0f;
                asset.shakeMin_y = 0f;
                asset.shakeMin_z = 0f;
            }
            else if (!NoShake && SDG.Unturned.Player.player.equipment.asset is ItemGunAsset)
            {
                var asset = SDG.Unturned.Player.player.equipment.asset as ItemGunAsset;
                var assetguid = asset.GUID;

                if (backupsshake.ContainsKey(assetguid))
                {
                    var backup = backupsshake[assetguid];

                    asset.shakeMax_x = backup.shakemaxx;
                    asset.shakeMax_y = backup.shakemaxy;
                    asset.shakeMax_z = backup.shakemaxz;
                    asset.shakeMin_x = backup.shakeminx;
                    asset.shakeMin_y = backup.shakeminy;
                    asset.shakeMin_z = backup.shakeminz;
                    
                    backupsshake.Remove(assetguid);
                }
            }
        }
        
        public void Update()
        {
            if (!Provider.isConnected) return;
            if (HackDirector.bSpying) return;
            
            SDG.Unturned.Player.player.look.isOrbiting = CameraFreeFlight;
            
            
//            checkWepHacks();
//            FOV.SetValue(SDG.Unturned.Player.player.look, Fov);
        }
    
        public void ContentGUI()
        {
            if (HackDirector.bSpying) return;


            //Player options
            NoRecoil = GUI.Toggle(new Rect(240, 30, 140, 20), NoRecoil, "No Recoil");
            NoShake = GUI.Toggle(new Rect(240, 53, 140, 20), NoShake, "No Shake");
            NoSpread = GUI.Toggle(new Rect(240, 75, 140, 20), NoSpread, "No Spread");
            NoDrop = GUI.Toggle(new Rect(240, 97, 140, 20), NoDrop, "No Drop");
            
//            AdvRangeFinder = GUI.Toggle(new Rect(240, 123, 144, 20), AdvRangeFinder, "Adv Finder");
            CameraFreeFlight = GUI.Toggle(new Rect(240, /*146*/123, 140, 20), CameraFreeFlight, "Camera Flight");
//            GUI.Label(new Rect(240, 165, 140, 20), $"Fov: {int.Parse(Fov.ToString())}");
//            Fov = GUI.HorizontalSlider(new Rect(240, 188, 140, 20), Fov, 10, 360);
            if (GUI.Button(new Rect(240, /*171*/149, 140, 30), "<size=13>Get High</size>"))
            {
                SDG.Unturned.Player.player.life.askView(30);
            }
            
            
        }
    
    }
}