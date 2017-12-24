
// ReSharper disable once CheckNamespace

using System;
using System.Collections.Generic;
using System.Reflection;
using SDG.Unturned;
using UnityEngine;
using Player = SDG.Unturned.Player;

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    internal partial class Aim
    {
        public static DateTime LastLock;
        public static Camera mainCamera;
        
        //aimlock
        public static float Defsense;    
        //-------
	    
        //triggerbot
        public static int Id;
	    
        public static FieldInfo Prim;
        public static FieldInfo Yaw;
        public static FieldInfo Pitch;
        //----------
	    
        //Aimbot
        public static List<Zombie> Zombies;
        public static int ZombieUpdate;
        public static List<SteamPlayer> Players;
        public static int PlayerUpdate;

        public static bool ZombieFlag;
        public static bool PlayerFlag;

        public static Transform target;
	    
        //------
        
        private void DerivedStart()
        {
            ZombieUpdate = 0;
            PlayerUpdate = 1;
	        
            Players = new List<SteamPlayer>();
            Zombies = new List<Zombie>();
	       
            LastLock = DateTime.Now;
	        
            Defsense = SDG.Unturned.Player.player.look.sensitivity;
            
            Prim = typeof(PlayerEquipment).GetField("prim", BindingFlags.Instance | BindingFlags.NonPublic);
            Yaw = typeof(PlayerLook).GetField("_yaw", BindingFlags.Instance | BindingFlags.NonPublic);
            Pitch = typeof(PlayerLook).GetField("_pitch", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        private void DerivedUpdate()
        {
            mainCamera = Camera.main;

            
            UpdateAim();
            UpdateLock();
            UpdateTB();
        }

        public void UpdateAim()
        {
            
        }

        public void UpdateLock()
        {

        }
        
        public void ChangeSense(bool enable)
        {
            if (enable)
                SDG.Unturned.Player.player.look.sensitivity = Defsense / LockSensitivity;
            else
                SDG.Unturned.Player.player.look.sensitivity = Defsense;
        }

        public void UpdateTB()
        {
            
        }
    }
}