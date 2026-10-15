using KRPGLib.Enchantment;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Toolsmith;
using Toolsmith.Utils;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace KRPGLib.Enchantment.Compat
{
    public class ToolsmithSystem : ModSystem
    {
        ICoreAPI Api;
        ICoreClientAPI cApi;
        ICoreServerAPI sApi;

        public bool ToolsmithSysEnchantCompatActive = false;
        public void StartClientSide(ICoreClientAPI capi)
        {
            if (!(capi is ICoreClientAPI)) return;
            cApi = capi;
            Api = capi as ICoreAPI;
            ToolsmithModSystem TSSys = capi.ModLoader.GetModSystem<ToolsmithModSystem>();
            if (TSSys != null)
            {
            }
        }
        public void StartServerSide(ICoreServerAPI sapi)
        {
            if (!(sapi is ICoreServerAPI)) return;
            sApi = sapi;
            Api = sapi as ICoreAPI;
            ToolsmithModSystem TSSys = sapi.ModLoader.GetModSystem<ToolsmithModSystem>();
            if (TSSys != null)
            {
                if (EnchantingConfigLoader.Config?.Debug == true) { Api.Logger.Event("[KRPGEnchantment] Did a thing."); }
            }
        }

        public void ToolsmithReversion(ICoreAPI Api, ItemSlot slot, int amount)
        {
            if (EnchantingConfigLoader.Config?.Debug == true) { Api.Logger.Event("[KRPGEnchantment] ha."); }

            if ((slot.Itemstack.GetToolhandleForData() != null) && (slot.Itemstack.GetToolhandleCurrentDurability() < slot.Itemstack.GetToolhandleMaxDurability()))
            {
                slot.Itemstack.SetToolhandleCurrentDurability(slot.Itemstack.GetToolhandleCurrentDurability() + amount);
            }
            if ((slot.Itemstack.GetToolbinding != null) && (slot.Itemstack.GetToolbindingCurrentDurability() < slot.Itemstack.GetToolbindingMaxDurability()))
            {
                slot.Itemstack.SetToolbindingCurrentDurability(slot.Itemstack.GetToolbindingCurrentDurability() + amount);
            }
        }
    }
}
