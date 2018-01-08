using MikePure.MikePure.Framework.Handler;
using MikePure.MikePure.Framework.Types.Enum;
using SDG.Unturned;
using UnityEngine;
// ReSharper disable MemberCanBePrivate.Global

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    internal partial class Visuals : MonoBehaviour
    {
        public static bool EnableVisuals;
        
        public static bool Player_Box2d;
        public static bool Player_Box3d;
        public static bool Player_Glow;
        public static bool Player_Skeleton;
        //public static  bool Tracers;
        public static bool Player_Name;
        public static bool Player_ShowWeapon;
        public static bool Player_ShowDistance;


        public static bool Zombie_Box2d;
        public static bool Zombie_Box3d;
        public static bool Zombie_Skeleton;
        //public static bool Zombie_Tracers;
        public static bool Zombie_ShowName;
        public static bool Zombie_ShowDistance;


        public static bool Item_Box3d;
        public static bool Item_ShowName;
        public static bool Item_ShowDistance;


        public static bool Vehicle_ShowName;
        public static bool Vehicle_ShowGas;
        public static bool Vehicle_ShowHealth;
        public static bool Vehicle_ShowDistance;
        public static bool Vehicle_FilterLocked;


        public static bool Storages_ShowName;
        public static bool Storages_ShowDistance;
        public static bool Storages_FilterLocked;

        public static bool Animal_ShowName;
        public static bool Animal_ShowDistance;


        public static float Altitude;
        public static NvType Nv;


        public static bool Setting_InfDistance;
        public static float Setting_Distance;
        public static float Setting_UpdateRate; //Member to set default value

        public static int page;

        public void Start()
        {
            EnableVisuals = true;
            
            Setting_Distance = 200f;
            Setting_UpdateRate = 20f;
            
            Nv = NvType.None;
            
            DerivedStart();
        }
    
        public void Update()
        {
            
        }    
    
        public void ContentGUI()
        {
            if (HackDirector.bSpying) return;
            
            if (GUI.Button(new Rect(240, 25, 90, 30), "<size=13>Player</size>"))
                page = 1;
            if (GUI.Button(new Rect(340, 25, 90, 30), "<size=13>Zombie</size>"))
                page = 2;
            if (GUI.Button(new Rect(440, 25, 90, 30), "<size=13>Item</size>"))
                page = 3;
            if (GUI.Button(new Rect(540, 25, 90, 30), "<size=13>Vehicles</size>"))
                page = 4;
            if (GUI.Button(new Rect(240, 58, 90, 30), "<size=13>Storages</size>"))
                page = 5;
            if (GUI.Button(new Rect(440, 58, 90, 30), "<size=13>Misc</size>"))
                page = 6;
            if (GUI.Button(new Rect(540, 58, 90, 30), "<size=13>Settings</size>"))
                page = 7;
            if (GUI.Button(new Rect(340, 58, 90, 30), "<size=13>Animals</size>"))
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
            GUI.Label(new Rect(400, 91, 100, 30), "<size=20>Players:</size>");

            Player_Box2d = GUI.Toggle(new Rect(240, 120, 140, 20), Player_Box2d, "2D Boxes");
            Player_Box3d = GUI.Toggle(new Rect(240, 143, 140, 20), Player_Box3d, "3D Boxes");
            Player_Glow = GUI.Toggle(new Rect(240, 166, 140, 20), Player_Glow, "Glow");
            Player_Skeleton = GUI.Toggle(new Rect(240, 189, 140, 20), Player_Skeleton, "Skeleton");
            Player_Name = GUI.Toggle(new Rect(240, 212, 144, 20), Player_Name, "Name");
            Player_ShowWeapon = GUI.Toggle(new Rect(240, 239, 140, 20), Player_ShowWeapon, "Weapon");
            Player_ShowDistance = GUI.Toggle(new Rect(240, 262, 140, 20), Player_ShowDistance, "Distance");
            if (GUI.Button(new Rect(240, 288, 140, 20), "Get High"))
            {
                SDG.Unturned.Player.player.life.askView(30);
            }

        }

        void ZombiePage()
        {
            GUI.Label(new Rect(400, 91, 100, 30), "<size=20>Zombies:</size>");

            Zombie_Box2d = GUI.Toggle(new Rect(240, 120, 140, 20), Zombie_Box2d, "2D Boxes");
            Zombie_Box3d = GUI.Toggle(new Rect(240, 143, 140, 20), Zombie_Box3d, "3D Boxes");
            Zombie_Skeleton = GUI.Toggle(new Rect(240, 170, 140, 20), Zombie_Skeleton, "Skeleton");
            Zombie_ShowName = GUI.Toggle(new Rect(240, 193, 140, 20), Zombie_ShowName, "Name");
            Zombie_ShowDistance = GUI.Toggle(new Rect(240, 216, 140, 20), Zombie_ShowDistance, "Distance");
        }

        void ItemPage()
        {
            GUI.Label(new Rect(410, 91, 100, 30), "<size=20>Items:</size>");

            Item_Box3d = GUI.Toggle(new Rect(240, 120, 140, 20), Item_Box3d, "3D Boxes");
            Item_ShowName = GUI.Toggle(new Rect(240, 147, 140, 20), Item_ShowName, "Name");
            Item_ShowDistance = GUI.Toggle(new Rect(240, 170, 140, 20), Item_ShowDistance, "Distance");
        }

        void VehiclePage()
        {
            GUI.Label(new Rect(400, 91, 100, 30), "<size=20>Vehicles:</size>");

            Vehicle_ShowName = GUI.Toggle(new Rect(240, 120, 140, 20), Vehicle_ShowName, "Name");
            Vehicle_ShowGas = GUI.Toggle(new Rect(240, 143, 140, 20), Vehicle_ShowGas, "Gas");
            Vehicle_ShowHealth = GUI.Toggle(new Rect(240, 166, 140, 20), Vehicle_ShowHealth, "Health");
            Vehicle_ShowDistance = GUI.Toggle(new Rect(240, 189, 140, 20), Vehicle_ShowDistance, "Distance");
            Vehicle_FilterLocked = GUI.Toggle(new Rect(240, 212, 140, 20), Vehicle_FilterLocked, "Filter Locked");
        }

        void StoragePage()
        {
            GUI.Label(new Rect(400, 91, 100, 30), "<size=20>Storages:</size>");

            Storages_ShowName = GUI.Toggle(new Rect(240, 120, 140, 20), Storages_ShowName, "Name");
            Storages_ShowDistance = GUI.Toggle(new Rect(240, 143, 140, 20), Storages_ShowDistance, "Distance");
            Storages_FilterLocked = GUI.Toggle(new Rect(240, 166, 140, 20), Storages_FilterLocked, "Filter Locked");
        }
        void AnimalPage()
        {
            GUI.Label(new Rect(400, 91, 100, 30), "<size=20>Animals:</size>");

            Animal_ShowName = GUI.Toggle(new Rect(240, 120, 140, 20), Animal_ShowName, "Name");
            Animal_ShowDistance = GUI.Toggle(new Rect(240, 143, 140, 20), Animal_ShowDistance, "Distance");
        }

        void MiscPage()
        {
            GUI.Label(new Rect(415, 91, 100, 30), "<size=20>Misc:</size>");

            if (GUI.Button(new Rect(240, 120, 140, 20), "No Rain"))
            {
                LevelLighting.rainyness = ELightingRain.NONE;
            }
            if (GUI.Button(new Rect(240, 143, 140, 20), "No Fog"))
            {
                RenderSettings.fog =(!RenderSettings.fog);
            }
            if (GUI.Button(new Rect(240, 166, 140, 20), "No Water"))
            {
                if (GUILayout.Button("No Water"))
                {
                    if (Altitude == 0f)
                        Altitude = LevelLighting.seaLevel;
                
                    LevelLighting.seaLevel = LevelLighting.seaLevel == 0f ? Altitude : 0f;
                }
            }
            
            GUI.Label(new Rect(240, 189, 140, 20), $"Night Vision: {Nv}");
            if(GUI.Button(new Rect(240, 212, 140, 20), "Military"))
            {
                Nv = NvType.Military;
                
                LevelLighting.vision = ELightingVision.MILITARY;
                LevelLighting.updateLighting();
                LevelLighting.updateLocal();
                PlayerLifeUI.updateGrayscale();
            }
            if (GUI.Button(new Rect(240, 235, 140, 20), "Civilian"))
            {
                Nv = NvType.Civilian;
                
                LevelLighting.vision = ELightingVision.CIVILIAN;
                LevelLighting.updateLighting();
                LevelLighting.updateLocal();
                PlayerLifeUI.updateGrayscale();
            }
            if (GUI.Button(new Rect(240, 258, 140, 20), "None"))
            {
                Nv = NvType.None;
                
                LevelLighting.vision = ELightingVision.NONE;
                LevelLighting.updateLighting();
                LevelLighting.updateLocal();
                PlayerLifeUI.updateGrayscale();
            }
            
            
           
        }

        void SettingsPage()
        {
            GUI.Label(new Rect(400, 91, 100, 30), "<size=20>Settings:</size>");

            Setting_InfDistance = GUI.Toggle(new Rect(240, 120, 140, 20), Setting_InfDistance, "Infnite Distance");


            GUI.Label(new Rect(240, 140, 140, 30), $"Distance: {Setting_Distance}");
            Setting_Distance = GUI.HorizontalSlider(new Rect(240, 160, 140, 20), Setting_Distance, 10, 1000); //Tweak This

            GUI.Label(new Rect(240, 170, 140, 30), $"Refresh Rate: {Setting_UpdateRate}");
            Setting_UpdateRate = GUI.HorizontalSlider(new Rect(240, 190, 140, 20), Setting_UpdateRate, 10, 100); //Tweak This
        }

    }
}