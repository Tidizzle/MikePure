using MikePure.MikePure.Framework.Loader;
using UnityEngine;

namespace MikePure.MikePure.Framework.Handler
{
    internal class AutoPilot : MonoBehaviour
    {
        public void Start()
        {
            HackDirector.Start();
            
            //Add implementation to this method
            LocalFileHelper.LoadAll();
        }

        public void Update()
        {
            HackDirector.Update();
        }
    }
}