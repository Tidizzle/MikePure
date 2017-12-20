using MikePure.MikePure.Framework.Handler;
using UnityEngine;
using GUI = UnityEngine.GUI;

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    internal partial class Aim : MonoBehaviour
    {

        public bool EnableAimbot;
        public bool EnableTriggerbot;
         
        public bool AimPlayers;
        public bool AimZombies;
       
        public bool AimClosest;
       
        public float AimSpeed;
        public bool AimIgnoreWalls;
       
        public float AimDistance;
        public bool AimInfDistance;
        public bool AimUseGunDistance;
       
        public bool AimSilent;
       
        public bool AimWhitelistFriends; 
        public bool AimWhitelistAdmins; 
        public bool AimWhitelistPlayers;
       
        public float AimFov;
        public bool Aim360;

        public bool AimFovCircle;
//        public TargetLimb AimTargetLimb;
        public int Limb;
        
        
        
        public bool TriggerPlayers;
        public bool TriggerZombies;
        public bool TriggerAnimals;
        public bool TriggerVehicles;
        public bool TriggerWhiteListFriends;
        public bool TriggerWhiteListAdmins;
        public bool TriggerWhiteListPlayers;
        public float TriggerDistance;
        public bool TriggerGunRange;
        
        public void Start()
        {
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
           
            
           

        }
    
    }
}