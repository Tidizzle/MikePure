namespace MikePure.MikePure.Framework.Types
{
    internal class Friend
    {
        public string sName;
        public ulong ulSteamId;

        public Friend(string name, ulong id)
        {
            sName = name;
            ulSteamId = id;
        }
    }
}