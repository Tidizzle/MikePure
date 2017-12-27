using MikePure.MikePure.Framework.Handler;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    internal class ItemSelection : MonoBehaviour
    {

        public bool EnableFilter;
        
        public bool FilterClothes;
        public bool FilterPacks;
        public bool FilterAmmo;
        public bool FilterGuns;
        public bool FilterAttach;
        public bool FilterFood;
        public bool FilterMed;
        public bool FilterWeapons;
        public bool FilterMisc;
        
        public void Start()
        {
    
        }
    
        public void Update()
        {
            if (HackDirector.bSpying) return;
        }
    
        public void GUI()
        {
            if (HackDirector.bSpying) return;
        }
    
    }
}