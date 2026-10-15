using KRPGLib.Enchantment;
using KRPGLib.Wands;
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
    public class ToolsmithSystem
    {
        ICoreAPI Api;
        ICoreClientAPI cApi;
        ICoreServerAPI sApi;

        public bool ToolsmithSysEnchantCompatActive = false;
        public void StartClientSide(ICoreAPI api)
        {
            if (!(api is ICoreClientAPI capi)) return;
        }
        public void StartServerSide(ICoreAPI api)
        {
            if (!(api is ICoreServerAPI sapi)) return;
        }

        public void ToolsmithReversion(ItemSlot slot, int amount)
        {
            if ((slot.Itemstack.GetToolhandleForData() != null) && (slot.Itemstack.GetToolhandleCurrentDurability() < slot.Itemstack.GetToolhandleMaxDurability()))
            {
                int remDurH = slot.Itemstack.GetToolhandleCurrentDurability();
                int maxDurH = slot.Itemstack.GetToolhandleMaxDurability();
                if (remDurH < maxDurH)
                {
                    remDurH += amount;
                    remDurH = Math.Min(remDurH, maxDurH);
                    slot.Itemstack.SetToolhandleCurrentDurability(remDurH);
                }
            }
            if ((slot.Itemstack.GetToolbinding() != null) && (slot.Itemstack.GetToolbindingCurrentDurability() < slot.Itemstack.GetToolbindingMaxDurability()))
            {
                int remDurB = slot.Itemstack.GetToolbindingCurrentDurability();
                int maxDurB = slot.Itemstack.GetToolbindingMaxDurability();
                if (remDurB < maxDurB)
                {
                    remDurB += amount;
                    remDurB = Math.Min(remDurB, maxDurB);
                    slot.Itemstack.SetToolbindingCurrentDurability(remDurB);
                }
            }
        }
    }
}
