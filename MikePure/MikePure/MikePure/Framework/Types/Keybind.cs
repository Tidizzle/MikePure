using UnityEngine;

namespace MikePure.MikePure.Framework.Types
{
    internal class Keybind
    {
        public KeyCode Key;
        public string bindName;
        public int bindId;

        public Keybind(string name, KeyCode key)
        {
            bindName = name;
            Key = key;
        }
    }
}