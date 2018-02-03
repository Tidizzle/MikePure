using System;
using Debug = UnityEngine.Debug;

namespace Dire_Wolf.DireWolf.Util
{
    public class Logging
    {
            public static void Exception(Exception e) => Debug.Log($"\n\n\n--- Exception @ {DateTime.Now} ---\n{e}\n--- END ---\n\n\n");
            public static void Log(string msg, string footer = "END") => Debug.Log($"\n\n------\n{msg} (@ {DateTime.Now.ToLongTimeString()})\n--- {footer} ---\n\n");
    }
}
