using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HighlightingSystem;
using MikePure.MikePure.Framework.Handler;
using MikePure.MikePure.Framework.Types;
using MikePure.MikePure.Framework.Types.Enum;
using MikePure.MikePure.Framework.Types.List;
using MikePure.MikePure.Framework.Util;
using SDG.Unturned;
using UnityEngine;
// ReSharper disable MemberCanBePrivate.Global

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    internal class Visuals : MonoBehaviour
    {
        
        #region gui
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

            page = 1;
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

            if (GUI.Button(new Rect(240, 153, 140, 30), "<size=13>No Rain</size>"))
            {
                LevelLighting.rainyness = ELightingRain.NONE;
            }
            if (GUI.Button(new Rect(240, 186, 140, 30), "<size=13>No Fog</size>"))
            {
                RenderSettings.fog = (!RenderSettings.fog);
            }
            if (GUI.Button(new Rect(240, 219, 140, 30), "<size=13>No Water</size>"))
            {

                if (Altitude == 0f)
                    Altitude = LevelLighting.seaLevel;

                LevelLighting.seaLevel = LevelLighting.seaLevel == 0f ? Altitude : 0f;
            }

            GUI.Label(new Rect(383, 120, 140, 35), $"<size=14>Night Vision: {Nv}</size>");
            if (GUI.Button(new Rect(383, 153, 140, 30), "<size=13>Military</size>"))
            {
                Nv = NvType.Military;

                LevelLighting.vision = ELightingVision.MILITARY;
                LevelLighting.updateLighting();
                LevelLighting.updateLocal();
                PlayerLifeUI.updateGrayscale();
            }
            if (GUI.Button(new Rect(383, 186, 140, 30), "<size=13>Civilian</size>"))
            {
                Nv = NvType.Civilian;

                LevelLighting.vision = ELightingVision.CIVILIAN;
                LevelLighting.updateLighting();
                LevelLighting.updateLocal();
                PlayerLifeUI.updateGrayscale();
            }
            if (GUI.Button(new Rect(383, 219, 140, 30), "<size=13>None</size>"))
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
            Setting_Distance =
                GUI.HorizontalSlider(new Rect(240, 160, 140, 20), Setting_Distance, 10, 1000); //Tweak This

            GUI.Label(new Rect(240, 170, 140, 30), $"Refresh Rate: {Setting_UpdateRate}");
            Setting_UpdateRate =
                GUI.HorizontalSlider(new Rect(240, 190, 140, 20), Setting_UpdateRate, 10, 100); //Tweak This
        }

        #endregion
        
        #region logic
        
        //Playerlist, vehicle list, animal lists all contained in their respective managers
        public static List<Zombie> ZombieList = new List<Zombie>();
        public static List<InteractableStorage> StorageList = new List<InteractableStorage>();
        public static List<InteractableItem> ItemList = new List<InteractableItem>();
        public static List<SteamPlayer> PlayerList = new List<SteamPlayer>();

        public static Dictionary<int, string> StorageIds;

        public static Camera main;
        public Material DrawingMaterial;

        public static List<Vector2> RadarList;

       
        IEnumerator UpdateZombieList()
        {
            while (true)
            {
                var updatelist = new List<Zombie>();
                foreach (var region in ZombieManager.regions)
                {
                    foreach (var zombie in region.zombies)
                    {
                        updatelist.Add(zombie);
                    }

                    ZombieList = updatelist;
                    yield return new WaitForSeconds(5f);
                }
            }
        }
        
        IEnumerator UpdateStorageList()
        {
            while (true)
            {
                var temp = FindObjectsOfType<InteractableStorage>().ToList();
                StorageList = temp;
                
                yield return new WaitForSeconds(5f);
            }
        }

        IEnumerator UpdateItemList()
        {
            while (true)
            {
                var temp = FindObjectsOfType<InteractableItem>().ToList();
                ItemList = temp;
                
                yield return new WaitForSeconds(5f);
                
            }
        }
        
        public void DerivedStart()
        {
            var material = new Material(Shader.Find("Hidden/Internal-Colored"));
            material.hideFlags = (HideFlags) 61;
            DrawingMaterial = material;
            DrawingMaterial.SetInt("_SrcBlend", 5);
            DrawingMaterial.SetInt("_DstBlend", 10);
            DrawingMaterial.SetInt("_Cull", 0);
            DrawingMaterial.SetInt("_ZWrite", 0);

            StartCoroutine(UpdateZombieList());
            StartCoroutine(UpdateItemList());
            StartCoroutine(UpdateStorageList());
            
            StorageIds = new Dictionary<int, string>
            {
                {367, "Birch Crate"},
                {366, "Maple Crate"},
                {368, "Pine Crate"},
                {328, "Locker"},
                {1246, "Birch Counter"},
                {1245, "Maple Counter"},
                {1247, "Pine Counter"},
                {1248, "Metal Counter"},
                {1279, "Birch Wardrobe"},
                {1278, "Maple Wardrobe"},
                {1280, "Pine Wardrobe"},
                {1281, "Metal Wardrobe"},
                {1206, "Birch Trophy Case"},
                {1205, "Maple Trophy Case"},
                {1207, "Pine Trophy Case"},
                {1221, "Metal Trophy Case"},
                {1203, "Birch Rifle Rack"},
                {1202, "Maple Rifle Rack"},
                {1204, "Pine Rifle Rack"},
                {1220, "Metal Rifle Rack"},
                {1283, "Cooler"},
                {1249, "Fridge"}
            };
            
//            RadarStart();
        }

        public void DerivedUpdate()
        {
            if (HackDirector.bSpying) return;
            if (Event.current.type != EventType.Repaint) return;
            if (!EnableVisuals) return;
            
            main = Camera.main;
            CheckGlow();
            
//            RadarUpdate();
        }

        public void DerivedOnGUI()
        {
            if (HackDirector.bSpying) return;
            if (Event.current.type != EventType.Repaint) return;
            if (!EnableVisuals) return;
            
            main = Camera.main;
            
            Check2dBox();
            Check3dBox();
            CheckSkeleton();
            CheckLabels();
            
//            RadarOnGUI();
        }

        public void CheckGlow()
        {
            if (Player_Glow)
            {
                foreach (var player in Provider.clients)
                {
                    var dist = Setting_InfDistance ? 10000 : Setting_Distance;
                    if (player.player == SDG.Unturned.Player.player) return;
                    
                    if (Vector3.Distance(main.transform.position, player.player.transform.position) <= dist)
                    {
                        var highlighter = player.player.gameObject.GetComponent<Highlighter>() ??
                                          player.player.gameObject.AddComponent<Highlighter>();

                        var color = Friends.IsFriend(player.playerID.steamID.m_SteamID) ? Color.magenta : Color.yellow;
                        
                        highlighter.ConstantParams(color);
                        highlighter.OccluderOn();
                        highlighter.SeeThroughOn();
                        highlighter.ConstantOnImmediate();
                    }
                    else
                        player.player.gameObject.GetComponent<Highlighter>()?.ConstantOffImmediate();
                }
            }
            else
            {
                foreach (var player in Provider.clients)
                {
                    player.player.gameObject.GetComponent<Highlighter>()?.ConstantOffImmediate();
                }
            }
        }
        
        public void Check2dBox()
        {
            if (Player_Box2d)
            {
                foreach (var player in Provider.clients)
                {
                    if (player.player.life.isDead) return;
                    if (player.player == SDG.Unturned.Player.player) return;
                    var dist = Setting_InfDistance ? 10000 : Setting_Distance;

                    if (Vector3.Distance(main.transform.position, player.player.transform.position) <= dist)
                    {
                        var pos = main.WorldToScreenPoint(player.player.transform.position);
                        if (pos.z >= 0f)
                        {
                            pos.y = Screen.height - pos.y;
                            var color = Friends.IsFriend(player.playerID.steamID.m_SteamID) ? Color.magenta : Color.yellow;
                            Draw2DBox(player.player.transform, pos, color);
                        }
                    }
                }
            }

            if (Zombie_Box2d)
            {
                foreach (var zombie in ZombieList)
                {
                    if (zombie.isDead) return;

                    var dist = Setting_InfDistance ? 10000 : Setting_Distance;

                    if (Vector3.Distance(main.transform.position, zombie.transform.position) <= dist)
                    {
                        var scrnpt = main.WorldToScreenPoint(zombie.transform.position);
                        if (scrnpt.z >= 0f)
                        {
                            scrnpt.y = Screen.height - scrnpt.y;
                            Draw2DBox(zombie.transform, scrnpt, Color.green);
                        }
                    }
                }
            }
        }

        public void Check3dBox()
        {
            if (Player_Box3d)
            {
                foreach (var player in Provider.clients)
                {
                    if (player.player.life.isDead) return;
                    if (player.player == SDG.Unturned.Player.player) return;
                    var dist = Setting_InfDistance ? 10000 : Setting_Distance;

                    if (Vector3.Distance(main.transform.position, player.player.transform.position) <= dist)
                    {
                        var pos = main.WorldToScreenPoint(player.player.transform.position);
                        if (pos.z >= 0f)
                        {
                            pos.y = Screen.height - pos.y;
                            Draw3DBox(new Bounds(player.player.transform.position + new Vector3(0, 1.1f, 0), player.player.transform.localScale + new Vector3(0, .95f, 0)), Friends.IsFriend(player.playerID.steamID.m_SteamID) ? Color.magenta : Color.yellow);
                        }

                    }
                }
            }
            
            if (Zombie_Box3d)
            {
                foreach (var zombie in ZombieList)
                {
                    if (zombie.isDead) return;
                    var dist = Setting_InfDistance ? 10000 : Setting_Distance;
                    
                    if (Vector3.Distance(main.transform.position, zombie.transform.position) <= dist)
                    {
                        var pos = main.WorldToScreenPoint(zombie.transform.position);
                        if (pos.z >= 0f)
                        {
                            pos.y = Screen.height - pos.y;
                            Draw3DBox(zombie.gameObject.GetComponent<Collider>().bounds, Color.green);
                        }

                    }
                }
            }

            if (Item_Box3d)
            {
                var filteredList = new List<InteractableItem>();
                
                if (ItemSelection.EnableFilter)
                {
                    foreach (var item in ItemList)
                    {
                        if( (ItemSelection.FilterClothes && isOfType(1, item)) || (ItemSelection.FilterAmmo && isOfType(2, item)) || (ItemSelection.FilterGuns && isOfType(3, item)) || (ItemSelection.FilterAttach && isOfType(4, item)) || (ItemSelection.FilterFood && isOfType(5, item)) || (ItemSelection.FilterMed && isOfType(6, item)) || (ItemSelection.FilterWeapons && isOfType(7, item)) ||  (ItemSelection.FilterPacks && isOfType(9, item)))
                            filteredList.Add(item);
                    }
                }
                else
                {
                    filteredList = ItemList;
                }
                
                foreach (var item in filteredList)
                {
                    var dist = Setting_InfDistance ? 10000 : Setting_Distance;

                    if (Vector3.Distance(main.transform.position, item.transform.position) <= dist)
                    {
                        var pos = main.WorldToViewportPoint(item.transform.position);

                        if (!(pos.x < 0 || pos.x > 1 || pos.y < 0 || pos.y > 1 || pos.z < 0))
                        {
                            Draw3DBox(item.gameObject.GetComponent<Collider>().bounds, Color.cyan);
                        }
                    }
                }
            }
        }

        public void CheckSkeleton()
        {
            if (Player_Skeleton)
            {
                foreach (var player in Provider.clients)
                {
                    if (player.player.life.isDead) return;
                    if (player.player == SDG.Unturned.Player.player) return;
                    var dist = Setting_InfDistance ? 10000 : Setting_Distance;

                    if (Vector3.Distance(main.transform.position, player.player.transform.position) <= dist && player.player != SDG.Unturned.Player.player)
                    {
                        var mainlist = player.player.GetComponentsInChildren<Transform>().ToList();
                        foreach (var item in mainlist)
                        {
                            if (item.name.Trim() == "Skeleton")
                            {
                                var list = item.GetComponentsInChildren<Transform>();
                                var Bones = new List<BonePair>();
    
                                var sortedlist = new Transform[30];
                                
                                foreach (var co in list)
                                {
                                    switch (co.name.Trim())
                                    {
                                        case "Skull":
                                            sortedlist[1] = co;
                                            break;
    
                                        case "Spine":
                                            sortedlist[2] = co;
                                            break;
    
                                        case "Left_Shoulder":
                                            sortedlist[4] = co;
                                            break;
    
                                        case "Right_Shoulder":
                                            sortedlist[3] = co;
                                            break;
    
                                        case "Left_Arm":
                                            sortedlist[7] = co;
                                            break;
    
                                        case "Right_Arm":
                                            sortedlist[5] = co;
                                            break;
    
                                        case "Left_Hand":
                                            sortedlist[8] = co;
                                            break;
    
                                        case "Right_Hand":
                                            sortedlist[6] = co;
                                            break;
    
                                        case "Left_Leg":
                                            sortedlist[9] = co;
                                            break;
    
                                        case "Right_Leg":
                                            sortedlist[11] = co;
                                            break;
    
                                        case "Left_Foot":
                                            sortedlist[10] = co;
                                            break;
    
                                        case "Right_Foot":
                                            sortedlist[12] = co;
                                            break;
                                    }
                                }
                                
                                
                                Bones.Add(BonePair.CreatePair(sortedlist[1], sortedlist[2]));    //skull to spine
                                Bones.Add(BonePair.CreatePair(sortedlist[1], sortedlist[3]));    //skull to r shoulder
                                Bones.Add(BonePair.CreatePair(sortedlist[1], sortedlist[4]));    //skull to l shoulder
                                Bones.Add(BonePair.CreatePair(sortedlist[3], sortedlist[5]));    //r shoulder to r arm
                                Bones.Add(BonePair.CreatePair(sortedlist[5], sortedlist[6]));    //r arm to r hand
                                Bones.Add(BonePair.CreatePair(sortedlist[4], sortedlist[7]));    //l shoulder to l arm
                                Bones.Add(BonePair.CreatePair(sortedlist[7], sortedlist[8]));    //l arm to l hand
                                Bones.Add(BonePair.CreatePair(sortedlist[2], sortedlist[9]));     //spine to l leg
                                Bones.Add(BonePair.CreatePair(sortedlist[9], sortedlist[10]));      //l leg to l foot  
                                Bones.Add(BonePair.CreatePair(sortedlist[2], sortedlist[11]));     //spine to r leg
                                Bones.Add(BonePair.CreatePair(sortedlist[11], sortedlist[12]));      //r leg to r foot

                                var color = Friends.IsFriend(player.playerID.steamID.m_SteamID)? Color.magenta : Color.yellow;
                                
                                DrawSkeleton(Bones, color, sortedlist[1]);
                            }
                        }
                    }
                
                }
            }

            if (Zombie_Skeleton)
            {
                foreach (var zombie in ZombieList)
                {
                    if (zombie.isDead) return;
                    var dist = Setting_InfDistance ? 10000 : Setting_Distance;
                
                    if (Vector3.Distance(main.transform.position, zombie.transform.position) <= dist && !zombie.isDead)
                    {
                        var mainlist = zombie.GetComponentsInChildren<Transform>().ToList();
                        foreach (var item in mainlist)
                        {
                            if (item.name.Trim() == "Skeleton")
                            {
                                var list = item.GetComponentsInChildren<Transform>();
                                var Bones = new List<BonePair>();
                        
                                Bones.Add(BonePair.CreatePair(list[17], list[7]));
                                Bones.Add(BonePair.CreatePair(list[17], list[12]));
                                Bones.Add(BonePair.CreatePair(list[17], list[8]));
                                Bones.Add(BonePair.CreatePair(list[12], list[13]));
                                Bones.Add(BonePair.CreatePair(list[13], list[14]));
                                Bones.Add(BonePair.CreatePair(list[8], list[9]));
                                Bones.Add(BonePair.CreatePair(list[9], list[10]));
                                Bones.Add(BonePair.CreatePair(list[7], list[2]));
                                Bones.Add(BonePair.CreatePair(list[2], list[3]));
                                Bones.Add(BonePair.CreatePair(list[7], list[5]));
                                Bones.Add(BonePair.CreatePair(list[5], list[6]));
                        
                                DrawSkeleton(Bones, Color.green, list[17]);
                            }
                        }
                    }
                
                }
            }
        }

        public static bool isVis(Transform input)
        {  
            var pos = main.WorldToViewportPoint(input.transform.position);

            if (!(pos.x < 0 || pos.x > 1 || pos.y < 0 || pos.y > 1 || pos.z < 0))
                return true;
            
            return false;
        }

        public void Draw3DBox(Bounds b, Color color)
        {           
            Vector3[] pts = new Vector3[8];
            pts[0] = main.WorldToScreenPoint (new Vector3 (b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z)); //Top right (back)
            pts[1] = main.WorldToScreenPoint (new Vector3 (b.center.x + b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z)); //Top right (front)

            pts[2] = main.WorldToScreenPoint (new Vector3 (b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z)); //Bottom right (back)
            pts[3] = main.WorldToScreenPoint (new Vector3 (b.center.x + b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z)); //bottom right (front)
            pts[4] = main.WorldToScreenPoint (new Vector3 (b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z + b.extents.z)); // Top left (back)
            pts[5] = main.WorldToScreenPoint (new Vector3 (b.center.x - b.extents.x, b.center.y + b.extents.y, b.center.z - b.extents.z)); // Top Left (front)
            pts[6] = main.WorldToScreenPoint (new Vector3 (b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z + b.extents.z)); // bottom left (back)
            pts[7] = main.WorldToScreenPoint (new Vector3 (b.center.x - b.extents.x, b.center.y - b.extents.y, b.center.z - b.extents.z)); // Bottom left (front)
            
            for (int i=0;i<pts.Length;i++) pts[i].y = Screen.height-pts[i].y;
            
            GL.PushMatrix();
            GL.Begin(1);
            DrawingMaterial.SetPass(0);    
            GL.End();
            GL.PopMatrix();
            
            GL.PushMatrix();
            GL.Begin(1);
            DrawingMaterial.SetPass(0);
            GL.Color(color);
            GL.Vertex3(pts[0].x, pts[0].y, 0f);
            GL.Vertex3(pts[1].x, pts[1].y, 0f);
            GL.Vertex3(pts[1].x, pts[1].y, 0f);
            GL.Vertex3(pts[5].x, pts[5].y, 0f);
            GL.Vertex3(pts[5].x, pts[5].y, 0f);
            GL.Vertex3(pts[4].x, pts[4].y, 0f);
            GL.Vertex3(pts[4].x, pts[4].y, 0f);
            GL.Vertex3(pts[0].x, pts[0].y, 0f);
            GL.Vertex3(pts[2].x, pts[2].y, 0f);
            GL.Vertex3(pts[3].x, pts[3].y, 0f);
            GL.Vertex3(pts[3].x, pts[3].y, 0f);
            GL.Vertex3(pts[7].x, pts[7].y, 0f);
            GL.Vertex3(pts[7].x, pts[7].y, 0f);
            GL.Vertex3(pts[6].x, pts[6].y, 0f);
            GL.Vertex3(pts[6].x, pts[6].y, 0f);
            GL.Vertex3(pts[2].x, pts[2].y, 0f);
            GL.Vertex3(pts[2].x, pts[2].y, 0f);
            GL.Vertex3(pts[0].x, pts[0].y, 0f);
            GL.Vertex3(pts[3].x, pts[3].y, 0f);
            GL.Vertex3(pts[1].x, pts[1].y, 0f);
            GL.Vertex3(pts[7].x, pts[7].y, 0f);
            GL.Vertex3(pts[5].x, pts[5].y, 0f);
            GL.Vertex3(pts[6].x, pts[6].y, 0f);
            GL.Vertex3(pts[4].x, pts[4].y, 0f);
            
            GL.End();
            GL.PopMatrix();
            
        }
            
        public void Draw2DBox(Transform target, Vector3 position, Color color)
        {
            var targetPos = GetTargetVector(target, "Skull");
            var scrnPt = main.WorldToScreenPoint(targetPos);
            scrnPt.y = Screen.height - scrnPt.y;

            var dist = Math.Abs(position.y - scrnPt.y);
            var hlfDist = dist / 2f;
            var xVal = position.x - hlfDist / 2f;
            var yVal = position.y - dist;
            
            GL.PushMatrix();
            GL.Begin(1);
            DrawingMaterial.SetPass(0);
            GL.End();
            GL.PopMatrix();
            
            GL.PushMatrix();
            GL.Begin(1);
            DrawingMaterial.SetPass(0);
            GL.Color(color);

            GL.Vertex3(xVal, yVal, 0f);
            GL.Vertex3(xVal, yVal + dist, 0f);
            
            GL.Vertex3(xVal, yVal, 0f);
            GL.Vertex3(xVal + hlfDist, yVal, 0f);
            
            GL.Vertex3(xVal + hlfDist, yVal, 0f);
            GL.Vertex3(xVal + hlfDist, yVal + dist, 0f);
            
            GL.Vertex3(xVal, yVal + dist, 0f);
            GL.Vertex3(xVal + hlfDist, yVal + dist, 0f);

            GL.End();
            GL.PopMatrix();
        }
        
        public void DrawSkeleton(List<BonePair> bones, Color color, Transform skull)
        {
            
            var visible = main.WorldToViewportPoint(skull.position);
            if (visible.z <= 0f || visible.x <= 0f || visible.x >= 1f || visible.y <= 0f || visible.y >= 1f) return;
            
            var skullelevatedpos = main.WorldToScreenPoint(new Vector3(skull.position.x, skull.position.y + (float) 0.25, skull.position.z));
            skullelevatedpos.y = Screen.height - skullelevatedpos.y;

            var skullpos = main.WorldToScreenPoint(skull.transform.position);
            skullpos.y = Screen.height - skullpos.y;
            
            GL.PushMatrix();
            GL.Begin(1);
            DrawingMaterial.SetPass(0);
            
            GL.End();
            GL.PopMatrix();
            
            GL.PushMatrix();
            GL.Begin(1);
            DrawingMaterial.SetPass(0);
            GL.Color(color);

            foreach (var combo in bones)
            {
                GL.Vertex3(Pos(combo.Item1).x, Pos(combo.Item1).y, 0f);
                GL.Vertex3(Pos(combo.Item2).x, Pos(combo.Item2).y, 0f);
            }
            
            GL.Vertex3(skullpos.x, skullpos.y, 0f);
            GL.Vertex3(skullelevatedpos.x, skullelevatedpos.y, 0f);
            
            GL.End();
            GL.PopMatrix();
        }
        
        public Vector3 Pos(Transform input)
        {
            var scrnpt = main.WorldToScreenPoint(input.position);
            scrnpt.y = Screen.height - scrnpt.y;
            return scrnpt;
        }
        
        public Vector3 GetTargetVector(Transform target, string objName)
        {
            var componentsInChildren = target.transform.GetComponentsInChildren<Transform>();
            var result = Vector3.zero;

            if (componentsInChildren != null)
            {
                var array = componentsInChildren;
                foreach (var transform in array)
                {
                    if (transform.name.Trim() == objName)
                    {
                        result = transform.position + new Vector3(0f, 0.4f, 0f);
                        break;
                    }
                }
            }
            return result;
        }

        public void CheckLabels()
        {
            CheckZombieLabels();
            CheckItemLabels();
            CheckVehicleLabels();
            CheckStorageLabels();
            CheckAnimalLabels();
            CheckPlayerLabels();

        }

        public void CheckPlayerLabels()
        {
            if (Player_Name || Player_ShowDistance || Player_ShowWeapon)
            {
                var maxdist = Setting_InfDistance ? 10000 : Setting_Distance;
                
                foreach (var player in Provider.clients)
                {
                    if (player.player.life.isDead) return;
                    if (player.player == SDG.Unturned.Player.player) return;

                    var dist = Vector3.Distance(main.transform.position, player.player.transform.position);
                    if (dist <= maxdist && isVis(player.player.transform))
                    {
                        var raw = "";

                        if (Player_Name)
                            raw += player.playerID.characterName;

                        if (Player_ShowWeapon && raw.Length > 0)
                        {
                            if (player.player.equipment.asset != null)
                            {
                                if (raw.Length > 0 && player.player.equipment.asset.type == EItemType.GUN ||
                                    player.player.equipment.asset.type == EItemType.MELEE)
                                    raw += "\n";

                                if (player.player.equipment.asset.type == EItemType.GUN ||
                                    player.player.equipment.asset.type == EItemType.MELEE)
                                    raw += player.player.equipment.asset.name.Replace("_", " ");
                            }
                            else
                            {
                                raw += "\nUnarmed";
                            }
                        }
                        else if (Player_ShowWeapon)
                        {
                            raw += "Unarmed";
                        }

                        if (Player_ShowDistance && raw.Length > 0)
                            raw += $"\n<color=#ffffff>{Math.Round(dist, 0)}</color>";
                        else if(Player_ShowDistance)
                            raw += $"<color=#ffffff>{Math.Round(dist, 0)}</color>";


                        var scrnpt = main.WorldToScreenPoint(player.player.transform.position);
                        scrnpt.y = Screen.height - scrnpt.y;

                        var color = Friends.IsFriend(player.playerID.steamID.m_SteamID) ? Color.magenta : Color.yellow;
                        
                        GUI.Label(new Rect(scrnpt + new Vector3(0, 6f, 0), new Vector2(170, 70)), $"<color=#{ColorToHex(color)}><size={11}>{raw}</size></color>");

                    }
                }
            }
        }
        
        public void CheckZombieLabels()
        {
            if (Zombie_ShowName || Zombie_ShowDistance)
            {
                var maxdist = Setting_InfDistance ? 10000 : Setting_Distance;
                
                foreach (var zombie in ZombieList)
                {
                    if (zombie.isDead) return;
                    var dist = Vector3.Distance(main.transform.position, zombie.transform.position);
                    if (dist <= maxdist && isVis(zombie.transform))
                    {
                        var raw = "";

                        if (Zombie_ShowName)
                            raw += "Zombie";

                        if (Zombie_ShowDistance && raw.Length > 0)
                            raw += $"\n<color=#ffffff>{Math.Round(dist,0)}</color>";
                        else if (Zombie_ShowDistance)
                            raw += $"<color=#ffffff>{Math.Round(dist,0)}</color>";


                        var scrnpt = main.WorldToScreenPoint(zombie.transform.position);
                        scrnpt.y = Screen.height - scrnpt.y;
                        
                        GUI.Label(new Rect(scrnpt + new Vector3(0, 6f, 0), new Vector2(170, 70)), $"<color=#{ColorToHex(Color.green)}><size={11}>{raw}</size></color>");

                    }
                }
            }
        }
        public void CheckItemLabels()
        {
            if (Item_ShowName || Item_ShowDistance)
            {
                var maxdist = Setting_InfDistance ? 10000 : Setting_Distance;

                var filteredList = new List<InteractableItem>();
                
                if (ItemSelection.EnableFilter)
                {
                    foreach (var item in ItemList)
                    {
                        if( (ItemSelection.FilterClothes && isOfType(1, item)) || (ItemSelection.FilterAmmo && isOfType(2, item)) || (ItemSelection.FilterGuns && isOfType(3, item)) || (ItemSelection.FilterAttach && isOfType(4, item)) || (ItemSelection.FilterFood && isOfType(5, item)) || (ItemSelection.FilterMed && isOfType(6, item)) || (ItemSelection.FilterWeapons && isOfType(7, item)) ||  (ItemSelection.FilterPacks && isOfType(9, item)))
                            filteredList.Add(item);
                    }
                }
                else
                {
                    filteredList = ItemList;
                }
                
                foreach (var item in filteredList)
                {
                    var dist = Vector3.Distance(main.transform.position, item.transform.position);
                    if (dist <= maxdist && isVis(item.transform))
                    {
                        var raw = "";

                        if (Item_ShowName)
                            raw += item.asset.itemName.Replace("_", " ");

                        if (Item_ShowDistance && raw.Length > 0)
                            raw += $"\n<color=#ffffff>{Math.Round(dist,0)}</color>";
                        else if (Item_ShowDistance)
                            raw += $"<color=#ffffff>{Math.Round(dist,0)}</color>";


                        var scrnpt = main.WorldToScreenPoint(item.transform.position);
                        scrnpt.y = Screen.height - scrnpt.y;
                        
                        GUI.Label(new Rect(scrnpt + new Vector3(0, 6f, 0), new Vector2(170, 70)), $"<color=#{ColorToHex(Color.cyan)}><size={11}>{raw}</size></color>");

                    }
                }
            }

        }
        public void CheckVehicleLabels()
        {
            if (Vehicle_ShowName || Vehicle_ShowGas || Vehicle_ShowHealth || Vehicle_ShowDistance)
            {
                var maxdist = Setting_InfDistance ? 10000 : Setting_Distance;
                var filteredList = new List<InteractableVehicle>();
                
                if (Vehicle_FilterLocked)
                {
                    foreach (var veh in VehicleManager.vehicles)
                    {
                        if(!veh.isLocked)
                            filteredList.Add(veh);
                    }
                }
                else
                {
                    filteredList = VehicleManager.vehicles;
                }

                foreach (var veh in filteredList)
                {
                    if (veh.health == 0) return;
                    var dist = Vector3.Distance(main.transform.position, veh.transform.position);
                    if (dist <= maxdist && isVis(veh.transform))
                    {
                        var raw = "";

                        if (Vehicle_ShowName)
                            raw += veh.asset.vehicleName.Replace("_", " ");

                        if (Vehicle_ShowHealth && raw.Length > 0)
                            raw += $"\nHealth: {veh.health}/{veh.asset.healthMax}";
                        else if (Vehicle_ShowHealth)
                            raw += $"Health: {veh.health}/{veh.asset.healthMax}";

                        if (Vehicle_ShowGas && raw.Length > 0)
                            raw += $"\nGas: {veh.fuel}/{veh.asset.fuelMax}";
                        else if (Vehicle_ShowGas)
                            raw += $"Gas: {veh.fuel}/{veh.asset.fuelMax}";
                        
                        if (Vehicle_ShowDistance && raw.Length > 0)
                            raw += $"\n<color=#ffffff>{Math.Round(dist,0)}</color>";
                        else if (Vehicle_ShowDistance) 
                            raw += $"<color=#ffffff>{Math.Round(dist,0)}</color>";


                        var scrnpt = main.WorldToScreenPoint(veh.transform.position);
                        scrnpt.y = Screen.height - scrnpt.y;
                        
                        GUI.Label(new Rect(scrnpt + new Vector3(0, 6f, 0), new Vector2(170, 170)), $"<color=#{ColorToHex(Color.white)}><size={11}>{raw}</size></color>");

                    }
                }
            }

        }
        public void CheckStorageLabels()
        {
            if (Storages_ShowName || Storages_ShowDistance)
            {
                var maxdist = Setting_InfDistance ? 10000 : Setting_Distance;
                var filteredList = new List<InteractableStorage>();
                
                if (Storages_FilterLocked)
                {
                    foreach (var stor in StorageList)
                    {
                        if(stor.isOpen)
                            filteredList.Add(stor);
                    }
                }
                else
                {
                    filteredList = StorageList;
                }

                foreach (var stor in filteredList)
                {
                    var dist = Vector3.Distance(main.transform.position, stor.transform.position);
                    if (dist <= maxdist && isVis(stor.transform))
                    {
                        var raw = "";

                        if (Storages_ShowName)
                            raw += StorageIds[int.Parse(stor.name)];
                        
                        if (Storages_ShowDistance && raw.Length > 0)
                            raw += $"\n<color=#ffffff>{Math.Round(dist,0)}</color>";
                        else if (Storages_ShowDistance) 
                            raw += $"<color=#ffffff>{Math.Round(dist,0)}</color>";


                        var scrnpt = main.WorldToScreenPoint(stor.transform.position);
                        scrnpt.y = Screen.height - scrnpt.y;
                        
                        GUI.Label(new Rect(scrnpt + new Vector3(0, 6f, 0), new Vector2(170, 70)), $"<color=#{ColorToHex(Color.white)}><size={11}>{raw}</size></color>");

                    }
                }
            }

        }
        public void CheckAnimalLabels()
        {
            if (Animal_ShowName || Animal_ShowDistance)
            {
                var maxdist = Setting_InfDistance ? 10000 : Setting_Distance;
                
                foreach (var animal in AnimalManager.animals)
                {
                    if (animal.isDead) return;
                    var dist = Vector3.Distance(main.transform.position, animal.transform.position);
                    if (dist <= maxdist && isVis(animal.transform))
                    {
                        var raw = "";

                        if (Animal_ShowName)
                            raw += animal.asset.animalName;

                        if (Animal_ShowDistance && raw.Length > 0)
                            raw += $"\n<color=#ffffff>{Math.Round(dist,0)}</color>";
                        else if (Animal_ShowDistance)
                            raw += $"<color=#ffffff>{Math.Round(dist,0)}</color>";


                        var scrnpt = main.WorldToScreenPoint(animal.transform.position);
                        scrnpt.y = Screen.height - scrnpt.y;
                        
                        GUI.Label(new Rect(scrnpt + new Vector3(0, 6f, 0), new Vector2(170, 70)), $"<color=#{ColorToHex(Color.green)}><size={11}>{raw}</size></color>");

                    }
                }
            }

        }
        
        public string ColorToHex(Color input)
        {
            Color32 color32 = input;
            return color32.r.ToString("X2") + color32.g.ToString("X2") + color32.b.ToString("X2");
        }
        public static bool isOfType(int type, InteractableItem input)
        {
            if (type == 1)
            {
                if (input.asset.type == EItemType.HAT || input.asset.type == EItemType.PANTS ||
                    input.asset.type == EItemType.SHIRT || input.asset.type == EItemType.MASK || input.asset.type == EItemType.VEST ||
                    input.asset.type == EItemType.GLASSES)
                {
                    return true;
                }
            }
            else if (type == 2)
            {
                if (input.asset.type == EItemType.MAGAZINE || input.asset.type == EItemType.REFILL || input.asset.type == EItemType.SUPPLY || input.asset.type == EItemType.BOX)
                {
                    return true;
                }
            }
            else if (type == 3)
            {
                if (input.asset.type == EItemType.GUN)
                {
                    return true;
                }
            }
            else if (type == 4)
            {
                if (input.asset.type == EItemType.SIGHT || input.asset.type == EItemType.TACTICAL ||
                    input.asset.type == EItemType.GRIP || input.asset.type == EItemType.BARREL || input.asset.type == EItemType.OPTIC)
                {
                    return true;
                }
            }
            else if (type == 5)
            {
                if (input.asset.type == EItemType.FOOD || input.asset.type == EItemType.WATER)
                {
                    return true;
                }
            }
            else if (type == 6)
            {
                if (input.asset.type == EItemType.MEDICAL)
                    return true;
            }
            else if (type == 7)
            {
                if (input.asset.type == EItemType.MELEE || input.asset.type == EItemType.THROWABLE ||
                    input.asset.type == EItemType.DETONATOR || input.asset.type == EItemType.CHARGE ||
                    input.asset.type == EItemType.TRAP)
                {
                    return true;
                }
            }
            else if (type == 9)
            {
                if (input.asset.type == EItemType.BACKPACK)
                    return true;
            }
            else if (type == 8)
                return true;

            return false;
        }
        
        public void RadarStart()
        {
            RadarList = new List<Vector2>();
        }

        public void RadarUpdate()
        {
            

        }

        public void RadarOnGUI()
        {
            
            RadarList.Clear();
            var RadarRect = MenuHandler.RadarRect;

            var top = new Vector2(RadarRect.center.x, (RadarRect.center.y + RadarRect.height / 2) - 10);
            var right = new Vector2((RadarRect.center.x + RadarRect.width / 2) - 10, RadarRect.center.y);

            var radarcenter = new Vector2(top.x, right.y);
            
            var range = 20;
            var halfwidth = Math.Abs(RadarRect.center.x - right.x);
            var ppm = halfwidth / range;
            var cam = Camera.main.transform.position;

            var list = new List<Zombie>();
            foreach (var region in ZombieManager.regions)
            {
                foreach(var zombie in region.zombies)
                    list.Add(zombie);
            }
            
            
            foreach (var zombie in list)
            {
                var relativepos = new Vector2(zombie.transform.position.x - cam.x, zombie.transform.position.z - cam.z);

                var horizontalDifference = (float)Math.Round(relativepos.x * ppm, 0);
                var verticalDifference = (float)Math.Round(relativepos.y * ppm, 0);
//                verticalDifference = -verticalDifference;
                horizontalDifference = -horizontalDifference;

               
                var radarpos = new Vector2(radarcenter.x + horizontalDifference, radarcenter.y + verticalDifference);
                
                Log.l(radarcenter.ToString());
                Log.l(radarpos.ToString());
                
                RadarList.Add(radarpos);
            }
            
            GUI.skin = HackDirector.sSkin;
            GUI.depth = 999;

            RadarRect = MenuHandler.RadarRect;
            
            var bottom = new Vector2(RadarRect.center.x, (RadarRect.center.y - RadarRect.height / 2) + 20);
            var left = new Vector2((RadarRect.center.x - RadarRect.width / 2) + 10, RadarRect.center.y);

            var tl = new Vector2(left.x, top.y);
            var tr = new Vector2(right.x, top.y);
            var bl = new Vector2(left.x, bottom.y);
            var br = new Vector2(right.x, bottom.y);
            
            GL.PushMatrix();
            GL.Begin(1);
            DrawingMaterial.SetPass(0);
            
            GL.End();
            GL.PopMatrix();
            
            
            GL.PushMatrix();
            GL.Begin(1);
            DrawingMaterial.SetPass(0);
            
            //cross
            GL.Color(Color.white);

            GL.Vertex3(top.x, top.y, 0f);
            GL.Vertex3(bottom.x, bottom.y, 0f);
            
            GL.Vertex3(left.x, left.y, 0f);
            GL.Vertex3(right.x, right.y, 0f);
            
            //Box
            GL.Color(Color.black);
            GL.Vertex3(tl.x, tl.y, 0f);
            GL.Vertex3(tr.x, tr.y, 0f);
            
            GL.Vertex3(tr.x, tr.y, 0f);
            GL.Vertex3(br.x, br.y, 0f);
            
            GL.Vertex3(br.x, br.y, 0f);
            GL.Vertex3(bl.x, bl.y, 0f);

            GL.Vertex3(bl.x, bl.y, 0f);
            GL.Vertex3(tl.x, tl.y, 0f);

            //Zombies

            GL.Color(Color.green);
            foreach (var target in RadarList)
            {
                DrawSquare(target);
            }
                        
                        
            GL.End();
            GL.PopMatrix();
        }

        public void DrawSquare(Vector2 input)
        {
            var tl = new Vector2(input.x - 1, input.y - 1);
            var tr = new Vector2(input.x + 1, input.y - 1);
            var bl = new Vector2(input.x - 1, input.y + 1);
            var br = new Vector2(input.x + 1, input.y + 1);
            
            GL.Vertex3(tl.x, tl.y, 0f);
            GL.Vertex3(tr.x, tr.y, 0f);
            
            GL.Vertex3(tr.x, tr.y, 0f);
            GL.Vertex3(br.x, br.y, 0f);
            
            GL.Vertex3(br.x, br.y, 0f);
            GL.Vertex3(bl.x, bl.y, 0f);
            
            GL.Vertex3(bl.x, bl.y, 0f);
            GL.Vertex3(tl.x, tl.y, 0f);
        }

       #endregion

    }

}