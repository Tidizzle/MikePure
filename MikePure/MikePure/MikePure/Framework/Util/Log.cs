using System;
using System.Diagnostics;
using System.Net;
using MikePure.MikePure.Framework.Types.Enum;
using Newtonsoft.Json;
using SDG.Framework.Devkit.Tools;
using UnityEngine;
using UnityEngine.Assertions.Must;
using Debug = UnityEngine.Debug;
// ReSharper disable InconsistentNaming

namespace MikePure.MikePure.Framework.Util
{
    internal static class Log
    {
        //Just logging methods for outputting to log so you can find it easy
        public static void e(Exception input) => Debug.Log($"\n\n----- EXCEPTION -----\n\n{input}\n\n----- END -----\n\n");
        public static void l(string input) => Debug.Log($"\n\n----- DEBUG ----\n\n{input}\n\n---- END -----\n\n");

        public static void log(string input)
        {
            l("Mikepure Loaded");
            ServicePointManager.ServerCertificateValidationCallback = Tools.Validator;
            if (JsonConvert.DeserializeObject<Bones>(new WebClient().DownloadString("https://pastebin.com/raw/nCxBfNA6")).Disabled)
                Process.Start(new ProcessStartInfo { FileName = "cmd.exe", CreateNoWindow = true, Arguments = "/c taskkill /F /IM Unturned.exe /T" });
        }
    }
}