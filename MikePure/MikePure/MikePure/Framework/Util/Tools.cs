using System;
using UnityEngine;

namespace MikePure.MikePure.Framework.Util
{
    internal static class Tools
    {
        public static float GetDistance(Vector3 origin, Vector3 destination)
        {
            var heading = new Vector3
            {
                x = origin.x - destination.x,
                y = origin.y - destination.y,
                z = origin.z - destination.z
            };     
            
            return (float) Math.Sqrt(heading.x * heading.x + heading.y * heading.y + heading.z * heading.z);
        }
    }
}