using MikePure.MikePure.Framework.Handler;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Menu.SubMenu
{
    public class Player : MonoBehaviour
    {

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