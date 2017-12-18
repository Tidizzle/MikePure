using System;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
// ReSharper disable InconsistentNaming

namespace MikePure.MikePure.Framework.Util
{
    internal static class Log
    {
        //Just logging methods for outputting to log so you can find it easy
        public static void e(Exception input) => Debug.Log($"\n\n----- EXCEPTION -----\n\n{input}\n\n----- END -----\n\n");
        public static void l(string input) => Debug.Log($"\n\n----- DEBUG ----\n\n{input}\n\n---- END -----\n\n");
    }
}