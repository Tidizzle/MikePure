
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
        public DateTime LastLock;
        public Camera mainCamera;
        
        //aimlock
        public float Defsense;    
        //-------
	    
        //triggerbot
        public static int Id;
	    
        public FieldInfo Prim;
        public FieldInfo Yaw;
        public FieldInfo Pitch;
        //----------
	    
        //Aimbot
        public List<Zombie> Zombies;
        public int ZombieUpdate;
        public List<SteamPlayer> Players;
        public int PlayerUpdate;

        public bool ZombieFlag;
        public bool PlayerFlag;

        public Transform target;
	    
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