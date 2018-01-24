
// ReSharper disable once CheckNamespace

using System;
using System.Collections.Generic;
using System.Reflection;
using MikePure.MikePure.Framework.Handler;
using MikePure.MikePure.Framework.Types.Enum;
using MikePure.MikePure.Framework.Types.List;
using MikePure.MikePure.Framework.Util;
using SDG.Unturned;
using UnityEngine;
using Player = SDG.Unturned.Player;
using Tools = MikePure.MikePure.Framework.Util.Tools;

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
	internal partial class Aim
	{
		public DateTime LastLock;
		public Camera mainCamera;

		public float Defsense;

		public static int Id;

		public FieldInfo Prim;
		public FieldInfo Yaw;
		public FieldInfo Pitch;

		public List<Zombie> Zombies;
		public List<SteamPlayer> Players;


		public static Transform target;
		public static int closest = int.MaxValue;

		private void DerivedStart()
		{
			Id = 0;
			
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
		    target = null;
		    
		    if (EnableAimbot)
		    {			    
			    //set target limb
			    var limb = AimTargetLimb == TargetLimb.Head ? "Skull" : "Spine";
			    var currClosest = float.PositiveInfinity;
			    
			    //set distance of aimbot
			    var distance = AimDistance;
			    if (AimUseGunDistance && SDG.Unturned.Player.player.equipment.asset is ItemGunAsset)
			    {
				    distance = (int)((ItemGunAsset) SDG.Unturned.Player.player.equipment.asset).range;
			    }
			    if (AimInfDistance)
			    {
				    distance = 10000;
			    }

			    if (AimZombies)
			    {
				    foreach (var zombie in Visuals.ZombieList)
				    {
					    if (zombie.isDead == false)
					    {
						    if (Vector3.Distance(mainCamera.transform.position, zombie.transform.position) <= distance)
						    {
							    //if I can see the player, or if 360 is enabled and I cant see the player
							    if (CanSee(zombie.transform) || Aim360 && !CanSee(zombie.transform))
							    {
									//if I can see the player, or if ignore walls is enabled and I cant see the player
	        					    RaycastHit hit;
//	        					    Physics.Raycast(Player.player.look.aim.position, zombie.transform.position, out hit, distance, RayMasks.DAMAGE_CLIENT);
								    var pos = GetLimbPosition(zombie.transform, limb);
								    var realpos = pos - SDG.Unturned.Player.player.look.aim.position;
								    Physics.Raycast(SDG.Unturned.Player.player.look.aim.position, realpos, out hit, distance, RayMasks.DAMAGE_CLIENT);
	        					   
								    if (hit.transform != null)
								    {
									    if (hit.transform.CompareTag("Zombie") || (AimIgnoreWalls && !hit.transform.CompareTag("Zombie")))
									    {

										    var targetpoint = mainCamera.WorldToScreenPoint(GetLimbPosition(zombie.transform, limb));
										    targetpoint.y = mainCamera.pixelHeight - targetpoint.y;
										    var centerpoint = new Vector3((float) mainCamera.pixelWidth / 2, (float) mainCamera.pixelHeight / 2);

										    var ppd = mainCamera.pixelWidth / mainCamera.fieldOfView;
										    var wafov = ((AimFov * ppd) / 2);

										    var distToXHair = Vector2.Distance(centerpoint, targetpoint);
										    if (!Aim360)
											    if (distToXHair > wafov) continue;

										    if (distToXHair > currClosest) continue;

										    currClosest = distToXHair;
										    target = zombie.transform;
									    }
								    }
	        					    
							    }
							    
						    }
					    }  
				}
			    
		    }

			    if (AimPlayers)
			    {
				    foreach (var player in Provider.clients)
				    {
					    var id = player.playerID.steamID.m_SteamID;
					    
					    if (player.player != SDG.Unturned.Player.player)
					    {
						    if (Friends.IsFriend(player.playerID.steamID.m_SteamID) && AimWhitelistFriends) continue;
						    if (player.isAdmin && AimWhitelistAdmins) continue;
						    
						    if (Vector3.Distance(mainCamera.transform.position, player.player.transform.position) <= distance)
						    {
							    if (CanSee(player.player.transform) || Aim360 && !CanSee(player.player.transform))
							    {
								    RaycastHit hit;
								    var pos = GetLimbPosition(player.player.transform, limb);
								    var realpos = pos - SDG.Unturned.Player.player.look.aim.position;
								    Physics.Raycast(SDG.Unturned.Player.player.look.aim.position, realpos, out hit, distance, RayMasks.DAMAGE_CLIENT);
								    
								    if (hit.transform != null)
								    {
									    if (hit.transform.CompareTag("Enemy") || (AimIgnoreWalls && !hit.transform.CompareTag("Enemy")))
									    {
										    var targetpoint = mainCamera.WorldToScreenPoint(GetLimbPosition(player.player.transform, limb));
										    targetpoint.y = mainCamera.pixelHeight - targetpoint.y;		    
										    var centerpoint = new Vector3((float) mainCamera.pixelWidth / 2, (float) mainCamera.pixelHeight / 2);
										    
										    var ppd = mainCamera.pixelWidth / mainCamera.fieldOfView;
										    var wafov = ((AimFov * ppd) / 2);
										    
										    var distToXHair = Vector2.Distance(centerpoint, targetpoint);
										    if (!Aim360)
											    if (distToXHair > wafov) continue;
										    
										    if (distToXHair > currClosest) continue;
										    
										    currClosest = distToXHair;
										    target = player.player.transform;
									    }
								    }
							    }
						    }   
					    }
				    }
			    }
			    
		        if (target != null)
		        {
			        if (AimSilent) return;
			        
				    var speed = AimSpeed / 4;
				    var targetVector = GetLimbPosition(target.transform, limb);
				    var quaternion = Quaternion.LookRotation(targetVector - SDG.Unturned.Player.player.look.aim.position);
				    var quaternion2 = Quaternion.RotateTowards(mainCamera.transform.rotation, quaternion, speed);
				    var xVal = quaternion2.eulerAngles.x;
						
				    if (xVal <= 90f)
				    {
					    xVal += 90f;
				    }
				    if (xVal > 180f)
				    {
					    xVal -= 270f;
				    }	
						
				    Yaw.SetValue(SDG.Unturned.Player.player.look, quaternion2.eulerAngles.y);
				    Pitch.SetValue(SDG.Unturned.Player.player.look, xVal);		
		        }
		    }
		}

	

	    
	    public static Vector3 GetLimbPosition(Transform target, string objName)
	    {
		    var componentsInChildren = target.transform.GetComponentsInChildren<Transform>();
		    var result = Vector3.zero;

		    if (componentsInChildren == null) return result;
			
		    foreach (var transform in componentsInChildren)
		    {
			    if (transform.name.Trim() != objName) continue;
					
			    result = transform.position + new Vector3(0f, 0.4f, 0f);
			    break;
		    }
			
		    return result;
	    }

	    public bool CanSee(Transform transform)
	    {
		    var scrnpt = mainCamera.WorldToViewportPoint(transform.position);

		    if (scrnpt.z <= 0f || scrnpt.x <= 0f || scrnpt.x >= 1f || scrnpt.y <= 0f || scrnpt.y >= 1f)
			    return false;
		    
		    return true;
	    }

        public void UpdateLock()
        {
	        if (EnableAimLock && Provider.isConnected)
	        {
		        var dist = LockInfDistance ? 10000 : LockDistance;

		        RaycastHit hit;
		        Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, dist,
			        RayMasks.DAMAGE_CLIENT);

		        if (hit.transform != null)
		        {	        
			        Log.l("5");

			        if (LockPlayers && hit.transform.CompareTag("Enemy"))
			        {	        
				        if (!LockWhiteListFriends && !IsPlayerFriend(hit))
				        {	        
						        SDG.Unturned.Player.player.look.sensitivity = Defsense / LockSensitivity;
				        }
			        }
			        else if (LockZombies && hit.transform.CompareTag("Zombie"))
				        SDG.Unturned.Player.player.look.sensitivity = Defsense / LockSensitivity;
			        else
				        SDG.Unturned.Player.player.look.sensitivity = Defsense;
		        }
		        else
			        SDG.Unturned.Player.player.look.sensitivity = Defsense;
	        }
        }

		public static bool IsPlayerFriend(RaycastHit rch)
		{
			if (rch.transform != null && rch.transform.CompareTag("Enemy"))
			{
				SteamPlayer ply = null;
				foreach (var client in Provider.clients)
				{
					if (client.player.gameObject == rch.transform.gameObject)
						ply = client;
					else
						ply = null;
				}
				
				if (ply != null)
				{
					if (Friends.IsFriend(ply.playerID.steamID.m_SteamID))
						return true;
					return false;
				}
			}
			
			return false;
		}

		
        public void UpdateTB()
        {
//	        if (EnableTriggerbot && Provider.isConnected)
             //	        {
             //		        var range = TriggerInfDistance ? 10000 : TriggerDistance;
             //
             //		        RaycastHit hit;
             //		        Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, range, RayMasks.DAMAGE_CLIENT);
             //
             //		        bool fire = false;
             //
             //		        if (hit.transform != null)
             //		        {
             //			        if (TriggerPlayers && hit.transform.CompareTag("Enemy"))
             //			        {
             //				        //if we are not whitelisting and player isnt friend
             //				        if (!(TriggerWhiteListFriends && IsPlayerFriend(hit)))
             //					        fire = true;
             //			        }
             //
             //			        if (TriggerZombies && hit.transform.CompareTag("Zombie"))
             //			        {
             //				        fire = true;
             //			        }
             //
             //			        if (fire)
             //			        {
             //				        Prim.SetValue(SDG.Unturned.Player.player.equipment, Id <= 3);
             //				        Id++;
             //				        if (Id > 6)
             //					        Id = 0;
             //			        }
             //
             //
             //		        }
             //	        }

		        
	        }
        }
    }
