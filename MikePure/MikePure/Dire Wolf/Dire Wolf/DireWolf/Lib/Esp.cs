using System;
using System.Collections;
using Dire_Wolf.DireWolf.Util;
using HighlightingSystem;
using SDG.Unturned;
using UnityEngine;
using Object = UnityEngine.Object;

// ReSharper disable once CheckNamespace
namespace Dire_Wolf.DireWolf.Menu
{
    internal partial class Esp 
    {
        private static Color color_0;
        private static GUIStyle guistyle = new GUIStyle(GUI.skin.label);
        private static Texture2D texture2D = new Texture2D(1, 1);

        public static void BoxRect(Rect rect, Color color)
        {
            if (color != color_0)
            {
                texture2D.SetPixel(0, 0, color);
                texture2D.Apply();
                color_0 = color;
            }
            GUI.DrawTexture(rect, texture2D);
        }

        public static void DrawBox(Vector2 pos, Vector2 size, float thick, Color color)
        {
            BoxRect(new Rect(pos.x, pos.y, size.x, thick), color);
            BoxRect(new Rect(pos.x, pos.y, thick, size.y), color);
            BoxRect(new Rect(pos.x + size.x, pos.y, thick, size.y), color);
            BoxRect(new Rect(pos.x, pos.y + size.y, size.x + thick, thick), color);
        }

        public static void DrawString(Vector2 pos, string text, Color color, bool center = true, int size = 12)
        {
            guistyle.fontSize = size;
            guistyle.normal.textColor = color;
            GUIContent content = new GUIContent(text);
            if (center)
            {
                pos.x -= guistyle.CalcSize(content).x / 2f;
            }
            GUI.Label(new Rect(pos.x, pos.y, 300f, 25f), content, guistyle);
        }
        
        private void NameBoxESP()
        {

            for (var  P = 0; P < Provider.clients.ToArray().Length; P++)
            {
                var newPlayerSteam = Provider.clients.ToArray()[P];
                if ((newPlayerSteam != null) && !newPlayerSteam.player.life.isDead)
                {
                    var camera = Camera.main;
                    var location = newPlayerSteam.player.transform.position;
                    var vector3 = camera.WorldToScreenPoint(location);
                    
                    if (vector3.z > 0)
                    {
                        float DiffrentPlayerDistance = (float)Math.Round(ToolMenu.GetDistance(newPlayerSteam.player.gameObject.transform.position), 0);

                        if (DiffrentPlayerDistance > 2)
                        {
                            if (DiffrentPlayerDistance <= EspDistance)
                            {
                                var vector2 = Camera.main.WorldToScreenPoint(location + new Vector3(0f, 1.7f, 0f));
                                var y = Mathf.Abs((float)(vector3.y - vector2.y));
                                var x = y / 2f;
                                Esp.DrawBox(new Vector2(vector2.x - (x / 2f), Screen.height - vector2.y), new Vector2(x, y), 1f, Color.red);
                                Esp.DrawString(new Vector2(vector3.x, Screen.height - vector3.y), string.Format("{0} [{1}M]", newPlayerSteam.playerID.playerName, DiffrentPlayerDistance), Color.red, true, 12);
                            }
                        }
                    }
                }
            } 
        }
        
        IEnumerator HighLightPlayers()
        {
            while (true)
            {

                if (!EspGlow || !Provider.isConnected || Provider.isLoading)
                {
                    yield return new WaitForSeconds(3f);
                    continue;
                }

                if (IsEspEnabled)
                {
                    for (var P = 0; P < Provider.clients.ToArray().Length; P++)
                    {
                        var newPlayerSteam = Provider.clients.ToArray()[P];
                        
                        if (newPlayerSteam != null && newPlayerSteam.player.gameObject != null && !newPlayerSteam.player.life.isDead)
                        {
                            var highlg = newPlayerSteam.player.gameObject.GetComponent<Highlighter>();
                            if (highlg == null)
                            {
                                highlg = newPlayerSteam.player.gameObject.AddComponent<Highlighter>();
                                highlg.SeeThroughOn();
                                highlg.OccluderOn();
                                highlg.ConstantOnImmediate(Color.red);
                            }

                            if (!EspGlow)
                            {
                                highlg.ConstantOffImmediate();
                                Object.Destroy(highlg);
                            }
                        }
                    }
                }
                yield return new WaitForSeconds(4f);
            }

        }

    }
}
