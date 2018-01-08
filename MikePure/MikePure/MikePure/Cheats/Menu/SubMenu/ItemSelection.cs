using MikePure.MikePure.Framework.Handler;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    internal class ItemSelection : MonoBehaviour
    {

        public static bool EnableFilter;
        
        public static bool FilterClothes;
        public static bool FilterPacks;
        public static bool FilterAmmo;
        public static bool FilterGuns;
        public static bool FilterAttach;
        public static bool FilterFood;
        public static bool FilterMed;
        public static bool FilterWeapons;
         
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
            
            EnableFilter = GUI.Toggle(new Rect(240, 30, 140, 20), EnableFilter, "Enable Filter");

            FilterClothes = GUI.Toggle(new Rect(240, 60, 140, 20), FilterClothes, "Clothes");
            FilterPacks = GUI.Toggle(new Rect(240, 83, 140, 20), FilterPacks, "Packs");
            FilterAmmo = GUI.Toggle(new Rect(240, 106, 140, 20), FilterAmmo, "Ammo");
            FilterGuns = GUI.Toggle(new Rect(240, 129, 140, 20), FilterGuns, "Guns");
            FilterAttach = GUI.Toggle(new Rect(240, 152, 140, 20), FilterAttach, "Attachments");
            FilterFood = GUI.Toggle(new Rect(240, 175, 140, 20), FilterFood, "Food");
            FilterMed = GUI.Toggle(new Rect(240, 198, 140, 20), FilterMed, "Medical");
            FilterWeapons = GUI.Toggle(new Rect(240, 221, 140, 20), FilterWeapons, "Weapons");
        }
    
    }
}