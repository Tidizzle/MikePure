using System.Collections;
using System.Linq;
using System.Reflection;
using Dire_Wolf.DireWolf.Menu;
using Dire_Wolf.DireWolf.Util;
using SDG.Unturned;
using UnityEngine;

namespace Dire_Wolf.DireWolf.Manager
{
    internal class Controller : MonoBehaviour
    {
        public static Menu.Menu Menu;
        public static Manager.Binds Binds;
        public static Menu.Aim Aim;
        public static Menu.Esp Esp;
        public static Menu.User User;
        
        public static bool MenuOpen = false;
        public static int CurrentMenu = 1;
        
        //GUI Skin
        public static GUISkin Skin;
        public static Texture Cursor;
        public static AssetBundle Bundle;

        //General
        public bool SayGreeting = true;
        
        private GameObject _obj;
        
        public void Start()
        {
            typeof(Provider).GetField("APP_NAME", BindingFlags.Static | BindingFlags.Public).SetValue(null, "MikePure Menu");
            typeof(Provider).GetField("APP_AUTHOR", BindingFlags.Static | BindingFlags.Public).SetValue(null, "Suflly and Tidal"); //<3

            StartCoroutine(LoadAssetBundle());
        }

        public void OnGUI()
        {
            if (Cursor == null)
            {
                Cursor = Resources.Load("UI/Cursor") as Texture;
            }
            GUI.skin = Skin;
        }
        
        private void Update()
        {
            if (Provider.isConnected && !Provider.isLoading && Provider.isInitialized && SayGreeting)
            {
                StartCoroutine(Greetings());
                SayGreeting = false;
            }        
            
            if (Provider.isConnected)
            {
                if (_obj == null)
                {
                    _obj = new GameObject();
                    Menu = _obj.AddComponent<Menu.Menu>();
                    Binds = _obj.AddComponent<Binds>();

                    Object.DontDestroyOnLoad(Menu);
                    Object.DontDestroyOnLoad(Binds);
                }
            }
            else
            {
                if (_obj != null)
                {
                    Object.Destroy(Menu);
                    Object.Destroy(Binds);

                    _obj = null;
                    Menu = null;
                    Binds = null;
                }
            }
        }
        
        
        
        IEnumerator LoadAssetBundle()
        {
            Bundle = AssetBundle.LoadFromFile(Application.dataPath + "\\resourcemanager.assetbundle", 0U);
            Skin = Bundle.LoadAllAssets<GUISkin>().First();
            yield break;
        }

        IEnumerator Greetings()
        {
            yield return new WaitForSeconds(5);
            ChatManager.sendChat(EChatMode.SAY, "Thank you for purchasing MikePure");
            ChatManager.sendChat(EChatMode.SAY, "Press F1 To open menu, Happy Hacking!");
        }
        

    }
}