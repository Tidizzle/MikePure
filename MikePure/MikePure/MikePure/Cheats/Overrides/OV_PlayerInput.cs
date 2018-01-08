using System.Collections.Generic;
using System.Reflection;
using MikePure.MikePure.Cheats.Menu;
using MikePure.MikePure.Cheats.Menu.SubMenu;
using SDG.Unturned;
using UnityEngine;
using Player = SDG.Unturned.Player;
using Tools = MikePure.MikePure.Framework.Util.Tools;

namespace MikePure.MikePure.Cheats.Overrides
{
    public class OV_PlayerInput
    {
        private PlayerInputPacket GetLatestPacket()
        {
            List<PlayerInputPacket> privateField = (List<PlayerInputPacket>)Player.player.input.GetType().GetField("clientsidePackets", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(Player.player.input);
            if (privateField == null)
                return null;
            return privateField[privateField.Count - 1];
        }
        
        public void sendRaycast(RaycastInfo info)
        {
            if (Aim.EnableAimbot && Aim.AimSilent && Aim.target != null)
            {
                Vector3 normal = (Aim.GetLimbPosition(Aim.target, "Skull") - Player.player.look.aim.position).normalized;
                info = DamageTool.raycast(new Ray(Player.player.look.aim.position, normal), 512f, RayMasks.DAMAGE_CLIENT);
            }
            if (Provider.isServer) // doesnt mess up singleplayer
            {
                InputInfo inputInfo = new InputInfo();
                inputInfo.animal = info.animal;
                inputInfo.direction = info.direction;
                inputInfo.limb = info.limb;
                inputInfo.material = info.material;
                inputInfo.normal = info.normal;
                inputInfo.player = info.player;
                inputInfo.point = info.point;
                inputInfo.transform = info.transform;
                inputInfo.vehicle = info.vehicle;
                inputInfo.zombie = info.zombie;
                inputInfo.section = info.section;
                if (inputInfo.player != null)
                    inputInfo.type = ERaycastInfoType.PLAYER;
                else if (inputInfo.zombie != null)
                    inputInfo.type = ERaycastInfoType.ZOMBIE;
                else if (inputInfo.animal != null)
                    inputInfo.type = ERaycastInfoType.ANIMAL;
                else if (inputInfo.vehicle != null)
                    inputInfo.type = ERaycastInfoType.VEHICLE;
                else if (inputInfo.transform != null)
                {
                    if (inputInfo.transform.CompareTag("Barricade"))
                        inputInfo.type = ERaycastInfoType.BARRICADE;
                    else if (info.transform.CompareTag("Structure"))
                        inputInfo.type = ERaycastInfoType.STRUCTURE;
                    else if (info.transform.CompareTag("Resource"))
                        inputInfo.type = ERaycastInfoType.RESOURCE;
                    else if (inputInfo.transform.CompareTag("Small") || inputInfo.transform.CompareTag("Medium") || inputInfo.transform.CompareTag("Large"))
                        inputInfo.type = ERaycastInfoType.OBJECT;
                    else if (info.transform.CompareTag("Ground") || info.transform.CompareTag("Environment"))
                        inputInfo.type = ERaycastInfoType.NONE;
                    else
                        inputInfo = null;
                }
                else
                    inputInfo = null;
                if (inputInfo != null)
                {
                    Queue<InputInfo> inputs = (Queue<InputInfo>)Player.player.input.GetType().GetField("inputs").GetValue(Player.player.input);
                    inputs.Enqueue(inputInfo);
                }
            }
            else
            {
                PlayerInputPacket playerInputPacket = GetLatestPacket();
                if (playerInputPacket.clientsideInputs == null)
                    playerInputPacket.clientsideInputs = new List<RaycastInfo>();
                if (Aim.EnableAimbot  && Aim.AimSilent && Aim.target != null)
                {
                    var player = Tools.GetPlayerFromTransform(Aim.target);
                    if (player != null)
                    {
                        info.player = player;
                        info.limb = ELimb.SKULL;
                    }
                }
                playerInputPacket.clientsideInputs.Add(info);
            }
        }
    }
}