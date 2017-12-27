using MikePure.MikePure.Framework.Handler;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    public partial class Visuals : MonoBehaviour
    {

        private bool Player_Box2d;
        private bool Player_Box3d;
        private bool Player_Glow;
        private bool Player_Skeleton;
        //private bool Tracers;
        private bool Player_Name;
        private bool Player_ShowWeapon;
        private bool Player_ShowDistance;


        private bool Zombie_Box2d;
        private bool Zombie_Box3d;
        private bool Zombie_Skeleton;
        //private bool Zombie_Tracers
        private bool Zombie_ShowName;
        private bool Zombie_ShowDistance;


        private bool Item_Box3d;
        private bool Item_ShowName;
        private bool Item_ShowDistance;


        private bool Vehicle_ShowName;
        private bool Vehicle_ShowGas;
        private bool Vehicle_ShowHealth;
        private bool Vehicle_ShowDistance;
        private bool Vehicle_FilterLocked;


        private bool Storages_ShowName;
        private bool Storages_ShowDistance;
        private bool Storages_FilterLocked;


        private bool Animal_Box3d;
        private bool Animal_ShowName;
        private bool Animal_ShowDistance;


        private bool Misc_NoRain;
        private bool Misc_NoFog;
        private bool Misc_NoWater;
        private bool Misc_mNV;
        private bool Misc_cNV;


        private bool Setting_InfDistance;
        private float Setting_Distance;
        private float Setting_UpdateRate; //Member to set default value

        private int page;

        public void Start()
        {
    
        }
    
        public void Update()
        {
            if (HackDirector.bSpying) return;
        }    
    
        public void ContentGUI()
        {
            if (HackDirector.bSpying) return;

            if (UnityEngine.GUI.Button(new Rect(240, 25, 90, 30), "<size=20>Player</size>"))
                page = 1;
            if (UnityEngine.GUI.Button(new Rect(340, 25, 90, 30), "<size=20>Zombie</size>"))
                page = 2;
            if (UnityEngine.GUI.Button(new Rect(440, 25, 90, 30), "<size=20>Item</size>"))
                page = 3;
            if (UnityEngine.GUI.Button(new Rect(540, 25, 90, 30), "<size=20>Vehicles</size>"))
                page = 4;
            if (UnityEngine.GUI.Button(new Rect(240, 58, 90, 30), "<size=18>Storages</size>"))
                page = 5;
            if (UnityEngine.GUI.Button(new Rect(440, 58, 90, 30), "<size=20>Misc</size>"))
                page = 6;
            if (UnityEngine.GUI.Button(new Rect(540, 58, 90, 30), "<size=19>Settings</size>"))
                page = 7;
            if (UnityEngine.GUI.Button(new Rect(340, 58, 90, 30), "<size=20>Animals</size>"))
                page = 8;




            //Content area
    

            switch (page)
            {
                case 1:
                    PlayerPage();
                    break;
                case 2:
                    ZombiePage();
                    break;
                case 3:
                    ItemPage();
                    break;
                case 4:
                    VehiclePage();
                    break;
                case 5:
                    StoragePage();
                    break;
                case 6:
                    MiscPage();
                    break;
                case 7:
                    SettingsPage();
                    break;
                case 8:
                    AnimalPage();
                    break;
            }
        }

        void PlayerPage()
        {
            UnityEngine.GUI.Label(new Rect(400, 91, 100, 30), "<size=20>Players:</size>");

            Player_Box2d = UnityEngine.GUI.Toggle(new Rect(240, 120, 140, 20), Player_Box2d, "2D Boxes");
            Player_Box3d = UnityEngine.GUI.Toggle(new Rect(240, 143, 140, 20), Player_Box3d, "3D Boxes");
            Player_Glow = UnityEngine.GUI.Toggle(new Rect(240, 166, 140, 20), Player_Glow, "Glow");
            Player_Skeleton = UnityEngine.GUI.Toggle(new Rect(240, 189, 140, 20), Player_Skeleton, "Skeleton");
            Player_Name = UnityEngine.GUI.Toggle(new Rect(240, 212, 140, 20), Player_Name, "Name");
            Player_ShowWeapon = UnityEngine.GUI.Toggle(new Rect(240, 235, 140, 20), Player_ShowWeapon, "Weapon");
            Player_ShowDistance = UnityEngine.GUI.Toggle(new Rect(240, 258, 140, 20), Player_ShowDistance, "Distance");
        }

        void ZombiePage()
        {
            UnityEngine.GUI.Label(new Rect(400, 91, 100, 30), "<size=20>Zombies:</size>");

            Zombie_Box2d = UnityEngine.GUI.Toggle(new Rect(240, 120, 140, 20), Zombie_Box2d, "2D Boxes");
            Zombie_Box3d = UnityEngine.GUI.Toggle(new Rect(240, 143, 140, 20), Zombie_Box3d, "3D Boxes");
            Zombie_Skeleton = UnityEngine.GUI.Toggle(new Rect(240, 166, 140, 20), Zombie_Skeleton, "Skeleton");
            Zombie_ShowName = UnityEngine.GUI.Toggle(new Rect(240, 189, 140, 20), Zombie_ShowName, "Name");
            Zombie_ShowDistance = UnityEngine.GUI.Toggle(new Rect(240, 212, 140, 20), Zombie_ShowDistance, "Distance");

        }

        void ItemPage()
        {
            UnityEngine.GUI.Label(new Rect(410, 91, 100, 30), "<size=20>Items:</size>");

            Item_Box3d = UnityEngine.GUI.Toggle(new Rect(240, 120, 140, 20), Item_Box3d, "3D Boxes");
            Item_ShowName = UnityEngine.GUI.Toggle(new Rect(240, 143, 140, 20), Item_ShowName, "Name");
            Item_ShowDistance = UnityEngine.GUI.Toggle(new Rect(240, 166, 140, 20), Item_ShowDistance, "Distance");
        }

        void VehiclePage()
        {
            UnityEngine.GUI.Label(new Rect(400, 91, 100, 30), "<size=20>Vehicles:</size>");

            Vehicle_ShowName = UnityEngine.GUI.Toggle(new Rect(240, 120, 140, 20), Vehicle_ShowName, "Name");
            Vehicle_ShowGas = UnityEngine.GUI.Toggle(new Rect(240, 143, 140, 20), Vehicle_ShowGas, "Gas");
            Vehicle_ShowHealth = UnityEngine.GUI.Toggle(new Rect(240, 166, 140, 20), Vehicle_ShowHealth, "Health");
            Vehicle_ShowDistance = UnityEngine.GUI.Toggle(new Rect(240, 189, 140, 20), Vehicle_ShowDistance, "Distance");
            Vehicle_FilterLocked = UnityEngine.GUI.Toggle(new Rect(240, 212, 140, 20), Vehicle_FilterLocked, "Filter Locked");
        }

        void StoragePage()
        {
            UnityEngine.GUI.Label(new Rect(400, 91, 100, 30), "<size=20>Storages:</size>");

            Storages_ShowName = UnityEngine.GUI.Toggle(new Rect(240, 120, 140, 20), Storages_ShowName, "Name");
            Storages_ShowDistance = UnityEngine.GUI.Toggle(new Rect(240, 143, 140, 20), Storages_ShowDistance, "Distance");
            Storages_FilterLocked = UnityEngine.GUI.Toggle(new Rect(240, 166, 140, 20), Storages_FilterLocked, "Filter Locked");
        }
        void AnimalPage()
        {
            UnityEngine.GUI.Label(new Rect(400, 91, 100, 30), "<size=20>Animals:</size>");

            Animal_Box3d = UnityEngine.GUI.Toggle(new Rect(240, 120, 140, 20), Animal_Box3d, "3D Box");
            Animal_ShowName = UnityEngine.GUI.Toggle(new Rect(240, 143, 140, 20), Animal_ShowName, "Name");
            Animal_ShowDistance = UnityEngine.GUI.Toggle(new Rect(240, 166, 140, 20), Animal_ShowDistance, "Distance");
        }

        void MiscPage()
        {
            UnityEngine.GUI.Label(new Rect(415, 91, 100, 30), "<size=20>Misc:</size>");

            Misc_NoRain = UnityEngine.GUI.Toggle(new Rect(240, 120, 140, 20), Misc_NoRain, "No Rain");
            Misc_NoFog = UnityEngine.GUI.Toggle(new Rect(240, 143, 140, 20), Misc_NoFog, "No Fog");
            Misc_NoWater = UnityEngine.GUI.Toggle(new Rect(240, 166, 140, 20), Misc_NoWater, "No Water");
            Misc_mNV = UnityEngine.GUI.Toggle(new Rect(240, 189, 140, 20), Misc_mNV, "Military NightVision");
            Misc_cNV = UnityEngine.GUI.Toggle(new Rect(240, 212, 140, 20), Misc_cNV, "Civilian NightVision");
        }

        void SettingsPage()
        {
            UnityEngine.GUI.Label(new Rect(400, 91, 100, 30), "<size=20>Settings:</size>");

            Setting_InfDistance = UnityEngine.GUI.Toggle(new Rect(240, 120, 140, 20), Setting_InfDistance, "Infnite Distance");


            UnityEngine.GUI.Label(new Rect(240, 140, 140, 30), "Distance: Float");
            Setting_Distance = UnityEngine.GUI.HorizontalSlider(new Rect(240, 160, 140, 20), Setting_Distance, 10, 100); //Tweak This

            UnityEngine.GUI.Label(new Rect(240, 170, 140, 30), "Refresh Rate: Float");
            Setting_UpdateRate = UnityEngine.GUI.HorizontalSlider(new Rect(240, 190, 140, 20), Setting_UpdateRate, 10, 100); //Tweak This
        }

    }
}