using System;
using System.Collections.Generic;
using System.Reflection;
using MikePure.MikePure.Framework.Handler;
using MikePure.MikePure.Framework.Types.Enum;
using MikePure.MikePure.Framework.Types.List;
using MikePure.MikePure.Framework.Util;
using SDG.Unturned;
using UnityEngine;
using GUI = UnityEngine.GUI;

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    internal  class Aim : MonoBehaviour
    {
	    
	    #region gui
        private int page;

        public static bool EnableAimbot;
        public static bool EnableTriggerbot;
        public static bool EnableAimLock;
        public static bool AimPlayers;
        public static bool AimZombies;
        public static bool AimClosest;
        public static int AimSpeed;
        public static bool AimIgnoreWalls;        
        public static int AimDistance;
        public static bool AimInfDistance;
        public static bool AimUseGunDistance;
        public static bool AimSilent;        
        public static bool AimWhitelistFriends; 
        public static bool AimWhitelistAdmins; 
        public static int AimFov;
        public static bool Aim360;
        public static bool AimFovCircle;
        public static TargetLimb AimTargetLimb;
        public static int Limb;
        
        
        
        public bool TriggerPlayers;
        public bool TriggerZombies;
        public bool TriggerWhiteListFriends;
        public bool TriggerWhiteListAdmins;
        public int TriggerDistance;
        public bool TriggerInfDistance;
        
        internal bool LockPlayers;
        internal bool LockZombies;
        internal int LockSensitivity;  
        internal int LockDistance;
        internal bool LockInfDistance;
        internal bool LockWhiteListFriends;
        internal bool LockWhitelistAdmins;
        
        public void Start()
        {
            page = 1;
            AimTargetLimb = TargetLimb.Head;
            Limb = 0;

            AimSpeed = 5;
            AimDistance = 200;
            AimFov = (int)Camera.main.fieldOfView;

            TriggerDistance = 200;

            LockSensitivity = 8;
            LockDistance = 200;
            
            DerivedStart();
        }
    
        public void Update()
        {
            if (HackDirector.bSpying) return;
            
            DerivedUpdate();
        }
    
        public void ContentGUI()
        {
            if (HackDirector.bSpying) return;
           
            //Top menu bar
            GUILayout.BeginHorizontal();

            if (GUILayout.Button("<size=15>Aimbot</size>", GUILayout.Width(100), GUILayout.Height(40)))
                page = 1;
//            if (GUILayout.Button("<size=15>Triggerbot</size>", GUILayout.Width(100), GUILayout.Height(40)))
//                page = 2;
            if (GUILayout.Button("<size=15>Aimlock</size>", GUILayout.Width(100), GUILayout.Height(40)))
                page = 3;
            GUILayout.EndHorizontal();
           
            GUILayout.Space(10f);
            
            //Content area
            GUILayout.BeginHorizontal();

            switch (page)
            {
                    case 1:
                        AimPage();
                        break;
                    case 2:
                        TriggerPage();
                        break;
                    case 3:
                        LockPage();
                        break;
            }
            
            GUILayout.EndHorizontal();
            
        }

        public void AimPage()
        {
             //Column 1
            GUILayout.BeginVertical();

            EnableAimbot = GUILayout.Toggle(EnableAimbot, "Enable", GUILayout.Width(200));
            GUILayout.Space(5f);
            AimPlayers = GUILayout.Toggle(AimPlayers, "Aim Players", GUILayout.Width(200));
            AimZombies = GUILayout.Toggle(AimZombies, "Aim Zombies", GUILayout.Width(200));
            GUILayout.Space(5f);
            AimIgnoreWalls = GUILayout.Toggle(AimIgnoreWalls, "Ignore Walls", GUILayout.Width(200));
            GUILayout.Space(3f);
            AimInfDistance = GUILayout.Toggle(AimInfDistance, "Infinite Distance", GUILayout.Width(200));
            AimUseGunDistance = GUILayout.Toggle(AimUseGunDistance, "Use Gun Range", GUILayout.Width(200));
            GUILayout.Space(3f);
            AimSilent = GUILayout.Toggle(AimSilent, "Silent Aim", GUILayout.Width(200));
            GUILayout.Space(3f);
            Aim360 = GUILayout.Toggle(Aim360, "360 FOV", GUILayout.Width(200));
//            AimFovCircle = GUILayout.Toggle(AimFovCircle, "Show FOV Circle", GUILayout.Width(200));
            
            GUILayout.EndVertical();
            
            
            //Column 2
            GUILayout.BeginVertical(GUILayout.MaxWidth(200));

            if (GUILayout.Button($"<size=15>Target Limb: {AimTargetLimb}</size>", GUILayout.Width(200)))
            {
                Limb++;

                if (Limb > 1)
                    Limb = 0;

                AimTargetLimb = (TargetLimb) Limb;
            }
            
            GUILayout.Label($"Aim Speed: {(int)AimSpeed}");
            AimSpeed = (int)GUILayout.HorizontalSlider(AimSpeed, 1, 50);
            
            GUILayout.Label($"Aim Distance: {(int)AimDistance}");
            AimDistance = (int)GUILayout.HorizontalSlider(AimDistance, 25, 1000);
            GUILayout.Label($"Aim FOV: {(int)AimFov}");
            AimFov = (int)GUILayout.HorizontalSlider(AimFov, 1, (int)Camera.main.fieldOfView);
                        
            GUILayout.Space(3f);
           
            AimWhitelistFriends = GUILayout.Toggle(AimWhitelistFriends, "Ignore Friends", GUILayout.Width(200));
            AimWhitelistAdmins = GUILayout.Toggle(AimWhitelistAdmins, "Ignore Admins", GUILayout.Width(200));
            
            GUILayout.EndVertical();
            
            
            
            GUILayout.Space(20f);
            
            
        }

        public void TriggerPage()
        {
             //Column 1
            GUILayout.BeginVertical();

            EnableTriggerbot = GUILayout.Toggle(EnableTriggerbot, "Enable", GUILayout.Width(200));
            GUILayout.Space(5f);
            TriggerPlayers = GUILayout.Toggle(TriggerPlayers, "Trigger Players", GUILayout.Width(200));
            TriggerZombies = GUILayout.Toggle(TriggerZombies, "Trigger Zombies", GUILayout.Width(200));
            GUILayout.Space(3f);
            TriggerInfDistance = GUILayout.Toggle(TriggerInfDistance, "Infinite Distance", GUILayout.Width(200));
            GUILayout.Space(3f);
            TriggerWhiteListFriends = GUILayout.Toggle(TriggerWhiteListFriends, "Ignore Friends", GUILayout.Width(200));
            TriggerWhiteListAdmins = GUILayout.Toggle(TriggerWhiteListAdmins, "Ignore Admins", GUILayout.Width(200));

            
            GUILayout.EndVertical();
            
            
            //Column 2
            GUILayout.BeginVertical(GUILayout.MaxWidth(200));
            
            GUILayout.Label($"Trigger Distance: {(int)TriggerDistance}");
            TriggerDistance = (int)GUILayout.HorizontalSlider(TriggerDistance, 50, 1000);
            GUILayout.Space(3f);

            
            GUILayout.EndVertical();
            
            GUILayout.Space(20f);
            
        }

        public void LockPage()
        {
            GUILayout.BeginVertical();

            EnableAimLock = GUILayout.Toggle(EnableAimLock, "Enable", GUILayout.Width(200));
            GUILayout.Space(5f);
            LockPlayers = GUILayout.Toggle(LockPlayers, "Lock Players", GUILayout.Width(200));
            LockZombies = GUILayout.Toggle(LockZombies, "Lock Zombies", GUILayout.Width(200));
            GUILayout.Space(3f);
            LockInfDistance = GUILayout.Toggle(LockInfDistance, "Infinite Distance", GUILayout.Width(200));
            GUILayout.Space(3f);
            LockWhiteListFriends = GUILayout.Toggle(LockWhiteListFriends, "Ignore Friends", GUILayout.Width(200));
            LockWhitelistAdmins = GUILayout.Toggle(LockWhitelistAdmins, "Ignore Admins", GUILayout.Width(200));       
            
            GUILayout.EndVertical();
            
            
            //Column 2
            GUILayout.BeginVertical(GUILayout.MaxWidth(200));
            
            GUILayout.Label($"Lock Sensitivity: {(int)LockSensitivity}");
            LockSensitivity = (int)GUILayout.HorizontalSlider(LockSensitivity, 2, 10);
            GUILayout.Space(3f);
            
            GUILayout.Label($"Distance: {LockDistance}");
            LockDistance = (int) GUILayout.HorizontalSlider(LockDistance, 50, 500);
            
            GUILayout.EndVertical();
            
            GUILayout.Space(20f);
            
        }
        
	    #endregion
	    
	    #region logic
	    
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
	    
	    	#endregion
	    
        }
    }
