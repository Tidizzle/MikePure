using System;
using MikePure.MikePure.Framework.Handler;
using MikePure.MikePure.Framework.Types.Enum;
using UnityEngine;
using GUI = UnityEngine.GUI;

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    internal partial class Aim : MonoBehaviour
    {
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
        public bool TriggerAnimals;
        public bool TriggerVehicles;
        public bool TriggerWhiteListFriends;
        public bool TriggerWhiteListAdmins;
        public int TriggerDistance;
        public bool TriggerGunRange;
        
        internal bool LockPlayers;
        internal bool LockZombies;
        internal bool LockAnimals;
        internal bool LockVehicles;
        
        internal int LockSensitivity;  
        internal int LockDistance; 
        internal bool LockGunRange;   
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

            if (GUILayout.Button("Aimbot", GUILayout.Width(100), GUILayout.Height(40)))
                page = 1;
            if (GUILayout.Button("Triggerbot", GUILayout.Width(100), GUILayout.Height(40)))
                page = 2;
            if (GUILayout.Button("Aimlock", GUILayout.Width(100), GUILayout.Height(40)))
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
            AimClosest = GUILayout.Toggle(AimClosest, "Aim Closest to Xhair", GUILayout.Width(200));
            GUILayout.Space(3f);
            AimSilent = GUILayout.Toggle(AimSilent, "Silent Aim", GUILayout.Width(200));
            GUILayout.Space(3f);
            AimWhitelistFriends = GUILayout.Toggle(AimWhitelistFriends, "Ignore Friends", GUILayout.Width(200));
            AimWhitelistAdmins = GUILayout.Toggle(AimWhitelistAdmins, "Ignore Admins", GUILayout.Width(200));
            GUILayout.Space(3f);
            Aim360 = GUILayout.Toggle(Aim360, "360 FOV", GUILayout.Width(200));
            AimFovCircle = GUILayout.Toggle(AimFovCircle, "Show FOV Circle", GUILayout.Width(200));

            
            GUILayout.EndVertical();
            
            
            //Column 2
            GUILayout.BeginVertical(GUILayout.MaxWidth(200));

            if (GUILayout.Button($"Target Limb: {AimTargetLimb}"))
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
            TriggerGunRange = GUILayout.Toggle(TriggerGunRange, "Use Gun Range", GUILayout.Width(200));
            GUILayout.Space(3f);
            TriggerWhiteListFriends = GUILayout.Toggle(TriggerWhiteListFriends, "Ignore Friends", GUILayout.Width(200));
            TriggerWhiteListAdmins = GUILayout.Toggle(TriggerWhiteListAdmins, "Ignore Admins", GUILayout.Width(200));

            
            GUILayout.EndVertical();
            
            
            //Column 2
            GUILayout.BeginVertical(GUILayout.MaxWidth(200));
            
            GUILayout.Label($"Trigger Distance: {(int)TriggerDistance}");
            TriggerDistance = (int)GUILayout.HorizontalSlider(TriggerDistance, 50, 1000);

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
            LockVehicles = GUILayout.Toggle(LockVehicles, "Lock Vehicles", GUILayout.Width(200));
            LockAnimals = GUILayout.Toggle(LockAnimals, "Lock Animals", GUILayout.Width(200));
            GUILayout.Space(3f);
            LockGunRange = GUILayout.Toggle(LockGunRange, "Use Gun Range", GUILayout.Width(200));
            GUILayout.Space(3f);
            LockWhiteListFriends = GUILayout.Toggle(LockWhiteListFriends, "Ignore Friends", GUILayout.Width(200));
            LockWhitelistAdmins = GUILayout.Toggle(LockWhitelistAdmins, "Ignore Admins", GUILayout.Width(200));       
            
            GUILayout.EndVertical();
            
            
            //Column 2
            GUILayout.BeginVertical(GUILayout.MaxWidth(200));
            
            GUILayout.Label($"Lock Sensitivity: {(int)LockSensitivity}");
            LockSensitivity = (int)GUILayout.HorizontalSlider(LockSensitivity, 2, 10);
                        
            GUILayout.EndVertical();
            
            GUILayout.Space(20f);
            
        }
    }
}