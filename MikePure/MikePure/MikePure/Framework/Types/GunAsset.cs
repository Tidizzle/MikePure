using SDG.Unturned;
// ReSharper disable InconsistentNaming

namespace MikePure.MikePure.Framework.Types
{
    internal class GunAsset
    {
        public System.Guid guid;
        public float fRecoilMinX;
        public float fRecoilMinY;
        public float fRecoilMaxX;
        public float fRecoilMaxY;

        public float fSpreadAim;
        public float fSpreadHip;

        public float fShakeMaxX;
        public float fShakeMaxY;
        public float fShakeMaxZ;
        public float fShakeMinX;
        public float fShakeMinY;
        public float fShakeMinZ;

        public float fBallisticForce;
        public float fBallisticDrop;
    
        public GunAsset(ItemGunAsset input)
        {
            fRecoilMaxX = input.recoilMax_x;
            fRecoilMaxY = input.recoilMax_y;
            fRecoilMinX = input.recoilMin_x;
            fRecoilMinY = input.recoilMin_y;

            fSpreadAim = input.spreadAim;
            fSpreadHip = input.spreadHip;

            fShakeMaxX = input.shakeMax_x;
            fShakeMaxY = input.shakeMax_y;
            fShakeMaxZ = input.shakeMax_z;
            fShakeMinX = input.shakeMin_x;
            fShakeMinY = input.shakeMin_y;
            fShakeMinZ = input.shakeMin_z;

            fBallisticForce = input.ballisticForce;
            fBallisticDrop = input.ballisticDrop;
        
            guid = input.GUID;
        }

    }
}