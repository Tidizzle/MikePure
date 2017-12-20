using System.Collections;
using MikePure.MikePure.Framework.Handler;
using SDG.Unturned;
using Steamworks;
using UnityEngine;

namespace MikePure.MikePure.Cheats.Overrides
{
    internal class OV_Player : MonoBehaviour
    {
        private static Texture2D screenshotRaw;
        private static Texture2D screenshotFinal;
        internal static Color[] oldColors;
        internal static Color[] newColors;
        internal static float widthRatio;
        internal static float heightRatio;
        internal static byte[] data;

        public void askScreenshot(CSteamID steamID)
        {
            if (Player.player.channel.checkServer(steamID))
                StartCoroutine(takeScreenshot());
        }

        private IEnumerator takeScreenshot()
        {
            HackDirector.bSpying = true;
            yield return new WaitForEndOfFrame();
            HackDirector.bSpying = true;
            if (screenshotRaw != null && (screenshotRaw.width != Screen.width || screenshotRaw.height != Screen.height))
            {
                UnityEngine.Object.DestroyImmediate(screenshotRaw);
                screenshotRaw = null;
            }
            if (screenshotRaw == null)
            {
                screenshotRaw = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
                screenshotRaw.name = "Screenshot_Raw";
                screenshotRaw.hideFlags = HideFlags.HideAndDontSave;
            }
            screenshotRaw.ReadPixels(new Rect(0f, 0f, (float)Screen.width, (float)Screen.height), 0, 0, false);
            if (screenshotFinal == null)
            {
                screenshotFinal = new Texture2D(640, 480, TextureFormat.RGB24, false);
                screenshotFinal.name = "Screenshot_Final";
                screenshotFinal.hideFlags = HideFlags.HideAndDontSave;
            }
            oldColors = screenshotRaw.GetPixels();
            newColors = new Color[screenshotFinal.width * screenshotFinal.height];
            widthRatio = (float)screenshotRaw.width / (float)screenshotFinal.width;
            heightRatio = (float)screenshotRaw.height / (float)screenshotFinal.height;
            for (int i = 0; i < screenshotFinal.height; i++)
            {
                int num2 = (int)((float)i * heightRatio) * screenshotRaw.width;
                int num3 = i * screenshotFinal.width;
                for (int j = 0; j < screenshotFinal.width; j++)
                {
                    int num4 = (int)((float)j * widthRatio);
                    newColors[num3 + j] = oldColors[num2 + num4];
                }
            }
            screenshotFinal.SetPixels(newColors);
            data = screenshotFinal.EncodeToJPG(33);
            if (data.Length < 30000)
            {
                Player.player.channel.longBinaryData = true;
                Player.player.channel.openWrite();
                Player.player.channel.write(data);
                Player.player.channel.closeWrite("tellScreenshotRelay", ESteamCall.SERVER, ESteamPacket.UPDATE_RELIABLE_CHUNK_BUFFER);
                Player.player.channel.longBinaryData = false;
            }
            yield return new WaitForEndOfFrame();
            HackDirector.bSpying = false;
        }
    }
}