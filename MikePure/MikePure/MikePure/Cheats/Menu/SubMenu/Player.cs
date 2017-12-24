using MikePure.MikePure.Framework.Handler;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    public class Player : MonoBehaviour
    {
        
        internal bool NoRecoil; 

        internal bool NoShake; 
        internal bool NoSpread; 
        internal bool NoDrop; 
        internal float Fov; 
        internal bool RangeFinder; 
        internal bool IncreaseInteractRange; 
        internal bool QuickSalvage; 
        internal bool CameraFreeFlight = false; 
        
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

            GUILayout.BeginHorizontal();
            
            //Player options
            GUILayout.BeginVertical();
            NoRecoil = GUILayout.Toggle(NoRecoil, "No Recoil", GUILayout.Width(150));
            NoShake = GUILayout.Toggle(NoShake, "No Shake", GUILayout.Width(150));
            NoSpread = GUILayout.Toggle(NoDrop, "No Drop", GUILayout.Width(150));
            GUILayout.EndVertical();
            
            //Player list
            GUILayout.BeginVertical();
            GUILayout.EndVertical();
            
            
            //Friends list
            GUILayout.BeginVertical();
            GUILayout.EndVertical();
            
            GUILayout.EndHorizontal();
        }
    
    }
}