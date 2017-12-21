
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
            if (EnableAimLock && Provider.isConnected)
            {
                var range = LockDistance;
                if (LockGunRange && SDG.Unturned.Player.player.equipment.asset is ItemGunAsset)
                {
                    range = (int)((ItemGunAsset) SDG.Unturned.Player.player.equipment.asset).range;
                }

                RaycastHit hit;
                Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range,
                    RayMasks.DAMAGE_CLIENT);

                if (hit.transform != null)
                {
                    if (LockPlayers && hit.transform.CompareTag("Enemy")) //if player
                    {
                        if (!AimWhitelistFriends && !IsPlayerFriend(hit, 1))
                            ChangeSense(true);
                        else
                            ChangeSense(false);
                    }
                    else if (LockZombies && hit.transform.CompareTag("Zombie")) //if zombie
                        ChangeSense(true);
                    else if (LockAnimals && hit.transform.CompareTag("Animal")) //if animal
                        ChangeSense(true);
                    else if (LockVehicles && hit.transform.CompareTag("Vehicle")) //if vehicle
                        ChangeSense(true);
                    else //if none
                        ChangeSense(false);

                }
                else
                    ChangeSense(false); //if transform is null

            }
            
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